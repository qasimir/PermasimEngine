using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Simulation {
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
            soilHorizons[0].porosity -= compactionTerm * dampeningTerm;
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
            } else {
                soilHorizons[0].soilNutrientManagers["Water"].amount = amount + amountToBeAbsorbed;
            }

            drainWaterThroughHorizons();
        }

        public void evaporateWater(float sumOfWindSpeeds) {
            // only used for evaporation of water at this point in time.
            float amount = soilHorizons[0].soilNutrientManagers["water"].amount;
            float evaporationRate = soilHorizons[0].soilNutrientManagers["water"].atmosphericRemovalRate;
            float waterToRemove = sumOfWindSpeeds * evaporationRate;

            if (waterToRemove > amount) {
                soilHorizons[0].soilNutrientManagers["water"].amount = 0;
            } else {
                soilHorizons[0].soilNutrientManagers["water"].amount = amount - waterToRemove;
            }
        }

        // TODO: approximation made here that only the first layer of soil can be dug. Alter this for depth.
        public void digSoil() {
            SoilHorizon soil = soilHorizons[0];
            // firstly, the soil becomes a great deal more porous.
            //TODO: have different modifiers for different soil types
            soil.porosity = soil.porosityAfterDigging;
            // secondly the soil biota decreases.
            soil.biota = soil.biotaAfterDigging;
            // thirdly aggregate stability decreases
            soil.aggregateStability = soil.aggregateStabilityAfterDigging;

            // also the amount of nutrient available increases
            foreach (string nutrientName in soil.soilNutrientManagers.Keys) {
                //we don't care about water here, because only water content is meaningful
                SoilNutrientManager nutrient = soil.soilNutrientManagers[nutrientName];
                nutrient.setAmountAvailableFactor(nutrient.postDiggingAvailability);
            }
        }

        public void flowWaterOnSurface(float volume) {
            // this method is called when the top layer soil profile is saturated
            // or rain run-off
        }

        public void drainWaterThroughHorizons() {
            //uses recursion to osmotically percolate water through the soil layers
        }

    }
}
