using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Simulation {
    public class SoilHorizonProcessor {

        public static void processSoil(ref SoilHorizon soilHorizon) {
            float dOdt;

            //calibrateSoilConstituents tertiary features first
            calibrateErosionFactor(ref soilHorizon);
            calibrateWaterContent(ref soilHorizon);
            calibrateNutrientVolatility(ref soilHorizon);
            calibrateAeration(ref soilHorizon);

            //calibrateSoilConstituents secondary features next
            calibrateAggregateStability(ref soilHorizon);
            calibrateBiota(ref soilHorizon);
            calibratePorosity(ref soilHorizon);

            //calibrateSoilConstituents primary features last
            calibrateOrganicMatter(ref soilHorizon, out dOdt);
            calibrateHumus(ref soilHorizon, dOdt);

        }

        private static void calibrateErosionFactor(ref SoilHorizon soilHorizon) {
            // should be a number between 0 and 1.
            // 0 means no soil erodes, 1 means it all erodes. 
            soilHorizon.erosionRate =
                soilHorizon.erosionRateAggregateStabilityConstant * soilHorizon.aggregateStability +
                soilHorizon.erosionRateSoilConstituentFactor;
        }

        private static void calibrateNutrientVolatility(ref SoilHorizon soilHorizon) {
            // should be a number between 0 and 1.
            // 0 means no nutrient is lost, 1 means it is all lost. 
            // Percent nutrient lost per 100mm of rain. (??)
            soilHorizon.nutrientVolatility = soilHorizon.nutrientVolatilitySoilConstituentFactor
                + soilHorizon.nutrientVolatilityHumusConstant * soilHorizon.getHumusPercent()
                + soilHorizon.nutrientVolatilityAggregateStabilityConstant * soilHorizon.aggregateStability;
        }

        private static void calibrateWaterContent(ref SoilHorizon soilHorizon) {
            // need weather events put in here
        }

        private static void calibrateAeration(ref SoilHorizon soilHorizon) {
            // need weather events put in here
        }

        private static void calibrateAggregateStability(ref SoilHorizon soilHorizon) {
            soilHorizon.aggregateStability = soilHorizon.aggregateStabilityBiotaConstant * soilHorizon.biota
                + soilHorizon.getHumusPercent() * soilHorizon.aggregateStabilityHumusConstant
                + soilHorizon.aggregateStabilitySoilConstituentFactor;
        }

        private static void calibrateBiota(ref SoilHorizon soilHorizon) {

            //For organic matter dB/dt = k1*O*B - k2*B
            float k1 = soilHorizon.biotaOrganicMatterConstant1;
            float k2 = soilHorizon.biotaOrganicMatterConstant2;
            float O = soilHorizon.organicMatter;
            float B = soilHorizon.biota;
            float dBdt_Om = k1 * O * B - k2 * B;

            //for water dB/dt = k3(W_optimal-W)
            float k3 = soilHorizon.biotaWaterConstant;
            float W_optimal = soilHorizon.biotaWaterOptimalGrowthConstant;
            float dBdt_W = k3 * (W_optimal - soilHorizon.soilNutrientManagers["water"].amount);

            // for temperature dB/dt = k3(T_optimal-T)
            float k4 = soilHorizon.biotaTemperatureConstant;
            float T_optimal = soilHorizon.biotaTemperatureOptimalGrowthConstant;
            float dBdt_T = k4 * (T_optimal - soilHorizon.temperature);

            float biotaDelta = dBdt_Om * dBdt_W * dBdt_T;

            soilHorizon.biota += biotaDelta;
        }

        private static void calibratePorosity(ref SoilHorizon soilHorizon) {
            // P = k1*As + k2 + k3*Hu
            float k1 = soilHorizon.porosityAggregateStabilityConstant;
            float aggregateStability = soilHorizon.aggregateStability;

            float k2 = soilHorizon.porositySoilCompositionalFactor;

            float k3 = soilHorizon.porosityHumusConstant;
            float humus = soilHorizon.getHumusPercent();

            soilHorizon.porosity = k1 * aggregateStability + k2 + k3 * humus;
        }

        private static void calibrateOrganicMatter(ref SoilHorizon soilHorizon, out float dOdt) {
            float O = soilHorizon.organicMatter;
            float B = soilHorizon.biota;
            float k1 = soilHorizon.organicMatterBiotaConstant;

            dOdt = -k1 * B * O;
            soilHorizon.organicMatter += dOdt;
        }

        private static void calibrateHumus(ref SoilHorizon soilHorizon, float dOdt) {
            // humusOrganicMatterConstant 
            // possibly this should be the inverse of the soil volume? 
            // We are altering the Humus pervcent here, so we might need to normalize.
            float humus = soilHorizon.getHumusPercent();
            humus += soilHorizon.humusOrganicMatterConstant * dOdt;
            soilHorizon.setHumusPercent(humus);
        }

    }
}

