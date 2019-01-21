using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantProcessor : MonoBehaviour {

    public void processPlant(Plant plant) {


        // calculate the tolerances, optimum levels, and sequestration rates
        float age = plant.age;
        float volume = (plant.rootDepth * plant.rootWidth) * 0.5f + plant.foliageHeight * plant.foliageWidth; //revise this, a cone has different volume


        // TODO: these two foreach loops can be merged at some point
        foreach (KeyValuePair<string, PlantNutrientManager> nutrient in plant.plantNutrientManagers) {
            nutrient.Value.assignNutrientTolerancesAndRates(volume, age);
            nutrient.Value.calculateSequestrationRates();
        }

        sequestNutrient(ref plant);

        float limitingGrowthFactor = float.PositiveInfinity;
        float growthFactor;
        foreach (string name in plant.plantNutrientManagers.Keys) {
            PlantNutrientManager nutrient = plant.plantNutrientManagers[name];
            setGrowthFactor(ref nutrient, ref plant, out growthFactor); //healthy, unhealthy etc
            if (growthFactor < limitingGrowthFactor) {
                limitingGrowthFactor = growthFactor;
            }
        }

        grow(limitingGrowthFactor, ref plant);

    }

   
   
    private void sequestNutrient(ref Plant plant) {
        Segment segment = plant.segment;
        float rootDepth = plant.rootDepth; //might overwrite, but shouldn't
        float rootRadius = plant.rootWidth / 2;
        SoilProfile soilProfile = segment.soilProfile;
        
        foreach (SoilHorizon soilHorizon in soilProfile.soilHorizons) {
            float x1 = Mathf.Abs(soilHorizon.upperBound);
            float x2 = Mathf.Abs(soilHorizon.lowerBound);
            x2 = x2 > rootDepth ? x2 : rootDepth;
            float volume = volumeInDiagonalSubsection(x1, x2,rootRadius,rootDepth);
            foreach  (string name in plant.plantNutrientManagers.Keys) {
                PlantNutrientManager nutrient = plant.plantNutrientManagers[name];
                nutrient.sequestNutrients(name, soilHorizon, volume);
            }

        }
        
    }

    // TODO: optimize this method. Too much stuff in the if statements.
    private void setGrowthFactor(ref PlantNutrientManager nutrient, ref Plant plant, out float growthFactor) {
        // TODO: currently a linear first approximation
        // consider changing this to gaussian distance
        // optimal growth factor is 1. 
        float a, b;
        bool belowOptimal = nutrient.currentLevel < nutrient.optimalLevel;


        if (nutrient.currentLevel<nutrient.minAliveTolerance || nutrient.currentLevel > nutrient.maxAliveTolerance) {
            growthFactor = -1;
            plant.isAlive = false;
            return;
        }

        // if the current level is between the healthy levels, then the growth is positive
        if (belowOptimal && nutrient.currentLevel > nutrient.minHealthyTolerance) {
            a = 1 / (nutrient.optimalLevel - nutrient.minHealthyTolerance);
            b = -1 * a * nutrient.minHealthyTolerance;
            float value = a * nutrient.currentLevel + b;
            nutrient.setNutrientGrowthFactor(value);
            growthFactor = value;
        } else if (!belowOptimal && nutrient.currentLevel < nutrient.maxHealthyTolerance) {
            a = 1 / (nutrient.optimalLevel - nutrient.maxHealthyTolerance);
            b = -1 * a * nutrient.maxHealthyTolerance;
            float value = a * nutrient.currentLevel + b;
            nutrient.setNutrientGrowthFactor(value);
            growthFactor = value;
        }
        else {
            // if the current levels are outside the bounds then the growth rates are zero.
            nutrient.setNutrientGrowthFactor(0);
            growthFactor = 0;
        }
    }

    private void grow(float limitingGrowthFactor, ref Plant plant) {
        // calculate the average of the growth rates. 
        // TODO: If the plant is dormant, then we don't want to age the plant, as the metabolic rate is near 0
        // TODO: add in a pest burden;
        plant.percentSizeOfOptimal = ((plant.percentSizeOfOptimal * plant.age) + limitingGrowthFactor) / (++plant.age);
        plant.totalSize = plant.percentSizeOfOptimal * maxPlantGrowthCurve(ref plant);
        plant.rootDepth = plant.rootDepthPercentTotal * plant.totalSize;
        plant.rootWidth = plant.rootWidthPercentTotal * plant.totalSize;
        plant.foliageHeight = plant.foliageHeightPercentTotal * plant.totalSize;
        plant.foliageWidth = plant.foliageWidthPercentTotal * plant.totalSize;
    }

    private float volumeInDiagonalSubsection(float x1,float x2, float r, float d) {
        float term1 = Mathf.Pow(r, 2) * x1 + (Mathf.Pow((r / d), 2) * Mathf.Pow(x1, 3)) / 3 - (Mathf.Pow(r, 2) * Mathf.Pow(x1, 2)) / d;
        float term2 = Mathf.Pow(r, 2) * x2 + (Mathf.Pow((r / d), 2) * Mathf.Pow(x2, 3)) / 3 - (Mathf.Pow(r, 2) * Mathf.Pow(x2, 2)) / d;
        return Mathf.Abs(Mathf.PI * (term1 - term2));
    }

    private float maxPlantGrowthCurve(ref Plant plant) {
        // growth curve should be of the form:
        // size = a*t^3 + b*t^2 (finitely bounded sigmoid shape)
        // unless the plant has passed maturity
        if (plant.age > plant.maxLifeTime) {
            return 0f;
        } else if (plant.age > plant.maturityTime) {
            return plant.maxSize;
        }
        // precalculated constants
        float a = -1 * plant.maxSize / (2 * Mathf.Pow(plant.maturityTime, 3));
        float b = (3 / 2) * (plant.maxSize / Mathf.Pow(plant.maturityTime, 2));

        return a * Mathf.Pow(plant.age, 3) + b * Mathf.Pow(plant.age, 2);
    }








}
