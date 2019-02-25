using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Simulation {
    public class SoilHorizon : MonoBehaviour {

        // fundamental varibles
        private float sandPercent;
        private float clayPercent;
        private float siltPercent;
        private float humusPercent;

        public Dictionary<string, SoilNutrientManager> soilNutrientManagers;

        // humus 
        public float humusOrganicMatterConstant;

        // organic matter
        public float organicMatter; // to be decayed to nutrients and humus
        public float organicMatterBiotaConstant;


        // temperature related
        public float temperature;
        public float thermalMass;

        // porosity related
        public float porosity;
        public float porosityHumusConstant;
        public float porosityAggregateStabilityConstant;
        public float porositySoilCompositionalFactor;
        public float porosityAfterDigging;

        public float compactionConstant;
        public float maximumCompaction;

        // biota related 
        public float biota;
        public float biotaAfterDigging;
        public float biotaHumusConstant;
        public float biotaOrganicMatterConstant1;
        public float biotaOrganicMatterConstant2;
        public float biotaWaterOptimalGrowthConstant;
        public float biotaWaterConstant;
        public float biotaTemperatureOptimalGrowthConstant;
        public float biotaTemperatureConstant;

        //related to aggregates and the stability of the aggregates
        public float aggregateStability;
        public float aggregateStabilitySoilConstituentFactor;
        public float aggregateStabilityHumusConstant;
        public float aggregateStabilityBiotaConstant;
        public float aggregateStabilityAfterDigging;


        // erosion
        public float erosionRate;
        public float erosionRateSoilConstituentFactor;
        public float erosionRateAggregateStabilityConstant;

        // nutrient volatility through ionic bonds in the soil
        public float nutrientVolatility;
        public float nutrientVolatilitySoilConstituentFactor;
        public float nutrientVolatilityAggregateStabilityConstant;
        public float nutrientVolatilityHumusConstant;



        public float phResistance;

        // this is the upper and lower bound for the soil type
        // they are expressed as negative numbers
        public float upperBound;
        public float lowerBound;

        public SoilHorizon() {
            soilNutrientManagers = new Dictionary<string, SoilNutrientManager>();
            soilNutrientManagers.Add("nitrogen", new SoilNutrientManager("nitrogen"));
            soilNutrientManagers.Add("phosphorus", new SoilNutrientManager("phosphorus"));
            soilNutrientManagers.Add("potassium", new SoilNutrientManager("potassium"));
            soilNutrientManagers.Add("traceMinerals", new SoilNutrientManager("traceMinerals"));
            soilNutrientManagers.Add("water", new SoilNutrientManager("water"));
        }

        public void normalizeSoilConstituents() {
            float total = sandPercent + siltPercent + clayPercent + humusPercent;
            sandPercent = sandPercent / total;
            siltPercent = siltPercent / total;
            clayPercent = clayPercent / total;
            humusPercent = humusPercent / total;
        }

        public float getSandPercent() {
            return sandPercent;
        }

        public float getSiltPercent() {
            return siltPercent;
        }

        public float getClayPercent() {
            return clayPercent;
        }

        public float getHumusPercent() {
            return humusPercent;
        }

        public void setSandPercent(float val) {
            sandPercent = val;
            normalizeSoilConstituents();
        }

        public void setSiltPercent(float val) {
            siltPercent = val;
            normalizeSoilConstituents();
        }

        public void setClayPercent(float val) {
            clayPercent = val;
            normalizeSoilConstituents();
        }

        public void setHumusPercent(float val) {
            humusPercent = val;
            normalizeSoilConstituents();
        }

        public float getAeration() {
            return porosity - soilNutrientManagers["water"].amount;
        }

    }
}

