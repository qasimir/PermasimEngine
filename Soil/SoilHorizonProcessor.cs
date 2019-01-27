using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SoilHorizonProcessor {

    public static void processSoil(ref SoilHorizon soilHorizon) {
        //calibrate tertiary features first
        caibrateWindErosionFactor();
        caibrateWaterErosionFactor();
        calibrateNutrientVolatility();
        calibrateWaterContent();
        calibrateAeration();

        //calibrate secondary features next
        calibrateAggregateStability();
        calibrateBiota();
        calibratePorosity();

        //calibrate primary features last
        calibrateOrgainicMatter();
        calibrateHumus();
        
    }

    private static void caibrateWindErosionFactor() {
        throw new NotImplementedException();
    }

    private static void caibrateWaterErosionFactor() {
        throw new NotImplementedException();
    }

    private static void calibrateNutrientVolatility() {
        throw new NotImplementedException();
    }

    private static void calibrateWaterContent() {
        throw new NotImplementedException();
    }

    private static void calibrateAeration() {
        throw new NotImplementedException();
    }

    private static void calibrateAggregateStability() {
        throw new NotImplementedException();
    }

    private static void calibrateBiota() {
        throw new NotImplementedException();
    }

    private static void calibratePorosity() {
        throw new NotImplementedException();
    }

    private static void calibrateOrgainicMatter() {
        throw new NotImplementedException();
    }

    private static void calibrateHumus() {
        throw new NotImplementedException();
    }

}

