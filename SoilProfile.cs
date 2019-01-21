using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilProfile : MonoBehaviour {

    public List<SoilHorizon> soilHorizons;
    public MulchLayer mulchLayer;

    // might have to change these to blocks of coords, for performance reasons
    public int x;
    public int y;

    public void applyMulch(OrganicMatter organicMatter) {
        // TODO: synthesize the Organic Matter with the existing mulch layer
    }

    public void compact(float compactionFactor) {
        float compactionTerm = compactionFactor * soilHorizons[0].compactionConstant;
        float dampeningTerm = soilHorizons[0].porosity - soilHorizons[0].maximumCompaction;
        soilHorizons[0].porosity -= compactionTerm*dampeningTerm;
    }

    public void applyWater(float volume) {
        float absorbtionRate = soilHorizons[0].soilNutrientManagers["water"].absorptionRate;
        float capacity = soilHorizons[0].soilNutrientManagers["water"].capacity;
        float amount = soilHorizons[0].soilNutrientManagers["water"].amount;
        float amountToBeAbsorbed = volume * absorbtionRate;
        float totalWaterAtSurface = amount + amountToBeAbsorbed;

        if (totalWaterAtSurface > capacity) {
            flowWaterOnSurface(totalWaterAtSurface - capacity);
            soilHorizons[0].soilNutrientManagers["Water"].amount = capacity;
        } 
        else {
            soilHorizons[0].soilNutrientManagers["Water"].amount = amount + amountToBeAbsorbed;
        }

        drainWaterThroughHorizons()
    }

    public void applyWind() {

    }

    public void digSoil() {

    }

    public void decompact() {
        // over time, soil will loosen up through mechanisms like
        // root penetration, temperature fluctuations, water evaporation etc.
    }

    public void flowWaterOnSurface(float volume) {
        // this method is called when the top layer soil profile is saturated
        // or rain run-off
    }

    public void drainWaterThroughHorizons() {
        //uses recursion to osmotically percolate water through the soil layers
    }

}
