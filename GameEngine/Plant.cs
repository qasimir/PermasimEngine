using Assets.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Plant : MonoBehaviour {

    public string name;

    public GameObject gameObject { get; set; }

    public int age { get; set; } // in weeks?
    protected int maxMaturity;

    // to do with size
    public float plantingDistance { get; set; } // in cm
    public float size { get; set; }
    public float maxSize; // refers to the maximum size of the edible crop

    // if this is zero or negative, then the plant dies
    protected float health { get; set; } // this is reduced by pests
    protected float heavinessOptimal;
    protected float temperatureOptimal;
    protected float temperatureUpperLimit;
    protected float temperatureLowerLimit;
    
    // water. Please note here the following points: the wilting point is taken to be the lower bound,
    // with the upper bound being either the saturation point or the field capacity, depending on the plant.
    protected float waterOptimal; // <- for most plants, the optimal water level will be the soil field capacity (a guess)
    protected float waterUpperLimit; // <- for most plants, the upper limit will be half way between the satuation and the field capacity(a guess)
    protected float waterLowerLimit; // <- for most plants, this will be the wilting point of the soil (a guess)

    public Plant(string name = "") {
        this.name = name;
    }

    public abstract void PlantInSoil(Soil soil);

        public void grow(ref Soil soil, float coordTemp) {
        // we need to produce a number between 0 and 1 corresponding to either
        // full growth, or no growth. If the plant continually grows at 1, then at maturity
        // it will have grown to the max size
        // there are 5 factors which affect the growth of a plant:
        // soil currentQuality
        // soil temp
        // air temp
        // water 
        // soil heaviness

        // we weight them linearly according to their linear distances from the optimum
        int numberOfIndependantGrowthFactors = 4;
        float soilQualityFactor = calculateSoilQualityFactor(ref soil, numberOfIndependantGrowthFactors);
        float temperatureFactor = calculateTemperatureFactor(ref soil, numberOfIndependantGrowthFactors, coordTemp);
        float waterFactor = calculateWaterFactor(ref soil, numberOfIndependantGrowthFactors);
        float heavinessFactor = calculateHeavinessFactor(ref soil, numberOfIndependantGrowthFactors);
        float totalGrowthFactor =
            health *
            (soilQualityFactor +
            temperatureFactor +
            waterFactor +
            heavinessFactor);

        size += calculateGrowth(totalGrowthFactor);
        age++;

    }

    private float calculateGrowth(float totalGrowthFactor) {
        // this is the incremental growth of one week
        return totalGrowthFactor * maxSize / maxMaturity;
    }

    private float calculateHeavinessFactor(ref Soil soil, int weight) {
        float heaviness = soil.getHeaviness();
        float bound;

        if (heaviness < heavinessOptimal) {
            bound = 0;
        } else {
            bound = 1;
        }

        float gradient;
        float intercept;

        generateLinearFunctionFromPoints(heavinessOptimal, 1, bound, 0, out gradient, out intercept);
        return (gradient * heaviness + intercept) / weight;
    }

    private float calculateWaterFactor(ref Soil soil, int weight) {
        float water = soil.getWater();
        float bound;

        if (water < waterOptimal) {
            bound = waterLowerLimit;
        }
        else {
            bound = waterUpperLimit;
        }

        float gradient;
        float intercept;

        generateLinearFunctionFromPoints(waterOptimal, 1, bound, 0, out gradient, out intercept);
        return (gradient * water + intercept)/weight;

    }

        

    private float calculateSoilQualityFactor(ref Soil soil, int weight) {
        return soil.getCurrentQuality()/weight;
    }

    private float calculateTemperatureFactor(ref Soil soil, int weight, float coordTemp) {
        float soilTemp = soil.getSoilTemp();
        float airTemp = coordTemp;

        float soilTemperatureBound;
        float airTemperatureBound;

        if (soilTemp<temperatureOptimal) {
            soilTemperatureBound = temperatureLowerLimit;
        } else {
            soilTemperatureBound = temperatureUpperLimit;
        }
        if (airTemp < temperatureOptimal) {
            airTemperatureBound = temperatureLowerLimit;
        } else {
            airTemperatureBound = temperatureUpperLimit;
        }

        float gradAir;
        float gradSoil;
        float interceptAir;
        float interceptSoil;

        generateLinearFunctionFromPoints(temperatureOptimal, 1, airTemperatureBound, 0, out gradAir, out interceptAir);
        generateLinearFunctionFromPoints(temperatureOptimal, 1, soilTemperatureBound, 0, out gradSoil, out interceptSoil);

        float airFactor = (gradAir * airTemp + interceptAir) / 2 * weight;
        float soilFactor = (gradSoil * soilTemp + interceptSoil) / 2 * weight;

        return airFactor + soilFactor;
    }

    private void generateLinearFunctionFromPoints(float x1, int y1, float x2, int y2, out float gradient, out float intercept) {
        gradient = (y1 - y2) / (x1 - x2);
        intercept = y1 - gradient * x1;
    }
}
