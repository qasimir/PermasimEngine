using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Soil {
    private float currentQuality { get; set; } // between 1 and 0
    private float baselineQuality { get; set; } // between 1 and 0. This lowers the wilting point between max and a half 
    private float heaviness { get; set; }
    private float water { get; set; }
    private float saturationPoint { get; set; }
    private float fieldCapacity { get; set; }
    private float wiltingPointBaseline { get; set; }
    private float soilTemp { get; set; }

    private float mulchVolume;

    private List<SoilEffect> soilEffects;

    public Soil() {
    }

    public void evolveSoil(bool cleanEffects) {
        float totalModifier = 0;
        for  (int i=0;i<soilEffects.Capacity;i++) {
            SoilEffect soilEffect = soilEffects[i];
            if (cleanEffects && soilEffect.needsCleaning()) {
                soilEffects.RemoveAt(i);
            } else {
                // here we multiply by the baseline quality to normalize
                totalModifier += baselineQuality * soilEffect.getModifierResult();
                soilEffect.incrementTimeElapsed();
            }
            currentQuality = totalModifier + baselineQuality;
        }
        decayOrganicMatter();
        recalibrateConstants();
    }

        

    public void dig() {
        // digging quality modifier = ae^-bx - ce^-dx + f
        float a = Parameters.diggingBonusAmplitude;
        float b = Parameters.diggingBonusDecay;
        float c = Parameters.diggingDetrimentAmplitude;
        float d = Parameters.diggingDetrimentDecay;

        SoilFunction bonus = new Exponential(a, b);
        SoilFunction detriment = new Exponential(-c, d);
        List<SoilFunction> terms = new List<SoilFunction>{bonus, detriment};
        SoilEffect effectOfDigging = new SoilEffect(terms);
        soilEffects.Add(effectOfDigging);
        incrementBaselineQuality(Parameters.soilDestructionFromDigging);
            
    }

    public void addWater(float amount) {
        // the quality of the soil determines the amount held
        water += amount;
        float waterSaturationLevel = saturationPoint;

        if (water > waterSaturationLevel) {
            water = waterSaturationLevel;
        }
        else if (water < 0) {
            water = 0;
        }

    }

    public void addMulch(float volumeMetersCubedPerCoordinate) {
        // slowly decays, adding to the soil quality
        this.mulchVolume += volumeMetersCubedPerCoordinate;
            
    }

    public void addHumus(float volumeMetersCubedPerCoordinate) {
        float increment = volumeMetersCubedPerCoordinate / Parameters.humusVolumeToSoilQuality;
        incrementBaselineQuality(increment);
    }

    private void decayOrganicMatter() {
        float mulchDecayed = mulchVolume * Parameters.mulchDecayConstant;
        addMulch(-mulchDecayed);
        float humusAdded = mulchVolume * Parameters.mulchToHumusVolumeReductionFactor;
        addHumus(humusAdded);
    }

    public void incrementBaselineQuality(float increment) {
        // we also need to alter the current value, 
        // as the soil effects will not know that they will need to tend to a different limit
        baselineQuality += increment;
        currentQuality += increment;

    }
    private void recalibrateConstants() {

        //making sure that it does not exceed the bounds
        if (currentQuality > 1) {
            currentQuality = 1;
        } else if (currentQuality < 0) {
            currentQuality = 0;
        }
        //making sure that it does not exceed the bounds
        if (baselineQuality > 1) {
            baselineQuality = 1;
        } else if (baselineQuality < 0) {
            baselineQuality = 0;
        }
    }

    internal float getCurrentQuality() {
        return currentQuality;
    }
    internal float getHeaviness() {
        return heaviness;
    }
    internal float getWater() {
        return water;
    }
    internal float getSoilTemp() {
        return soilTemp;
    }
    internal float getFieldCapacity() {
        return fieldCapacity;
    }
    internal float getSaturationPoint() {
        return saturationPoint;
    }
    internal float getWiltingPointEffective() {
        // quality of 1 will reduce the wilting point by 1/2. (a guess)
        float subtractant = currentQuality * (wiltingPointBaseline / 2);
        return wiltingPointBaseline - subtractant;
    }

}
