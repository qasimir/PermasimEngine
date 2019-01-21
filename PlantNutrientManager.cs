using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PlantNutrientManager : NutrientManager {

    private float nutrientGrowthFactor;

    public float currentLevel;
    public float optimalLevel; 
    public float maxHealthyTolerance;
    public float minHealthyTolerance;
    public float maxAliveTolerance;
    public float minAliveTolerance;
    public float currentSequestrationRate;
    public float maxSequestrationRate;
    public float minSequestrationRate;

    public float optimalLevelSetterConstant;
    public float maxHealthyToleranceSetterConstant;
    public float minHealthyToleranceSetterConstant;
    public float maxAliveToleranceSetterConstant;
    public float minAliveToleranceSetterConstant;
    public float maxSequestrationRateSetterConstant;
    public float minSequestrationRateSetterConstant;

    public PlantNutrientManager(string name) : base(name) {
        
    }


    internal void assignNutrientTolerancesAndRates(float volume, float age) {
        float volumeAge = volume * age;

        optimalLevel = optimalLevelSetterConstant * volumeAge;
        maxHealthyTolerance = maxHealthyToleranceSetterConstant * volumeAge;
        minHealthyTolerance = minHealthyToleranceSetterConstant * volumeAge;
        maxAliveTolerance = maxAliveToleranceSetterConstant * volumeAge;
        minAliveTolerance = minAliveToleranceSetterConstant * volumeAge;
        maxSequestrationRate = maxHealthyToleranceSetterConstant * volumeAge;
        minSequestrationRate = maxHealthyToleranceSetterConstant * volumeAge;
    }

    internal void calculateSequestrationRates() {
        if (currentLevel <= minHealthyTolerance) {
            currentSequestrationRate = maxSequestrationRate;
        } 
        else if (currentLevel >= optimalLevel) {
            currentSequestrationRate = minSequestrationRate;
        }
        else {
            float aNumerator = maxSequestrationRate - minSequestrationRate;
            float aDenominator1 = Mathf.Pow(minHealthyTolerance, 2) - Mathf.Pow(optimalLevel, 2);
            float aDenominator2 = 2 * optimalLevel * (minHealthyTolerance - optimalLevel);
            float aDenominator = aDenominator1 - aDenominator2;
            float a = aNumerator / aDenominator;
            float b = -2 * a * optimalLevel;
            float c = maxSequestrationRate - a * Mathf.Pow(minHealthyTolerance, 2) - b * minHealthyTolerance;
            currentSequestrationRate = a * Mathf.Pow(currentLevel, 2) + b * currentLevel + c;
        }

    }

    internal void sequestNutrients(string nutrientName, SoilHorizon soilHorizon, float volume) {
        currentLevel += volume * currentSequestrationRate * soilHorizon.soilNutrientManagers[nutrientName].availability;
    }

    public void setNutrientGrowthFactor(float growthFactor) {
        this.nutrientGrowthFactor = growthFactor;
    }

}

