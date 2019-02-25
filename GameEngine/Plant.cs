using Assets.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Plant {

    public string name;

    private int age { get; set; } // in weeks?
    private int maxMaturity;
        
    // to do with size
    private float size { get; set; }
    private float maxSize;

    // if this is zero or negative, then the plant dies
    private float health { get; set; }
    private float heavinessOptimal;
    private float temperatureOptimal;
    private float temperatureUpperLimit;
    private float temperatureLowerLimit;
    private float waterOptimal;
    private float waterUpperLimit;
    private float waterLowerLimit;

    public Plant(string name = "") {
        this.name = name;
    }

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

        float soilQualityFactor = calculateSoilQualityFactor(ref soil, 4);
        float temperatureFactor = calculateTemperatureFactor(ref soil, 4, coordTemp);
        float waterFactor = calculateWaterFactor(ref soil, 4);
        float heavinessFactor = calculateHeavinessFactor(ref soil, 4 );
        float totalGrowthFactor =
            soilQualityFactor +
            temperatureFactor +
            waterFactor +
            heavinessFactor;

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
