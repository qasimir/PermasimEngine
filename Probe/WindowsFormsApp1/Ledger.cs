using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1 {
    class Ledger {
        private int time;
        List<DataPoint> nitrogen = new List<DataPoint>();
        List<DataPoint> phosphorus= new List<DataPoint>();
        List<DataPoint> potassium = new List<DataPoint>();
        List<DataPoint> traceMinerals = new List<DataPoint>();
        List<DataPoint> biota = new List<DataPoint>();
        List<DataPoint> porosity = new List<DataPoint>();
        List<DataPoint> water = new List<DataPoint>();
        List<DataPoint> aeration = new List<DataPoint>();
        List<DataPoint> erosionFactor = new List<DataPoint>();
        List<DataPoint> nutrientVolatility = new List<DataPoint>();
        List<DataPoint> humus = new List<DataPoint>();
        List<DataPoint> organicMatter = new List<DataPoint>();
        List<DataPoint> aggregateStability = new List<DataPoint>();

        public Ledger() {
            this.time = 0;
        }

        public void updateLedger() {
            SoilHorizon soilHorizon = WorldMap.instance.segments[0, 0].soilProfile.soilHorizons[0];

            float nitrogenAmount = soilHorizon.soilNutrientManagers["nitrogen"].amount;
            float phosphorusAmount = soilHorizon.soilNutrientManagers["phosphorus"].amount;
            float potassiumAmount = soilHorizon.soilNutrientManagers["potassium"].amount;
            float traceMineralsAmount = soilHorizon.soilNutrientManagers["traceMinerals"].amount;
            float waterAmount = soilHorizon.soilNutrientManagers["water"].amount;
            float biotaAmount = soilHorizon.biota;
            float porosityAmount = soilHorizon.porosity;
            float aerationAmount = soilHorizon.getAeration();
            float erosionFactorAmount = soilHorizon.erosionRate;
            float nutrientVolatilityAmount = soilHorizon.nutrientVolatility;
            float humusAmount = soilHorizon.getHumusPercent();
            float organicMatterAmount = soilHorizon.organicMatter;
            float aggregateStabilityAmount = soilHorizon.aggregateStability;

            DataPoint nitrogenDataPoint = new DataPoint(time, nitrogenAmount);
            DataPoint phosphorusDataPoint = new DataPoint(time, phosphorusAmount);
            DataPoint potassiumDataPoint = new DataPoint(time, potassiumAmount);
            DataPoint traceMineralsDataPoint = new DataPoint(time, traceMineralsAmount);
            DataPoint biotaDataPoint = new DataPoint(time, biotaAmount);
            DataPoint porosityDataPoint = new DataPoint(time, porosityAmount);
            DataPoint waterDataPoint = new DataPoint(time, waterAmount);
            DataPoint aerationDataPoint = new DataPoint(time, aerationAmount);
            DataPoint erosionFactorDataPoint = new DataPoint(time, erosionFactorAmount);
            DataPoint nutrientVolatilityDataPoint = new DataPoint(time, nutrientVolatilityAmount);
            DataPoint humusDataPoint = new DataPoint(time, humusAmount);
            DataPoint organicMatterDataPoint = new DataPoint(time, organicMatterAmount);
            DataPoint aggregateStabilityDataPoint = new DataPoint(time, aggregateStabilityAmount);

            nitrogen.Add(nitrogenDataPoint);
            phosphorus.Add(phosphorusDataPoint);
            potassium.Add(potassiumDataPoint);
            traceMinerals.Add(traceMineralsDataPoint);
            biota.Add(biotaDataPoint);
            porosity.Add(porosityDataPoint);
            water.Add(waterDataPoint);
            aeration.Add(aerationDataPoint);
            erosionFactor.Add(erosionFactorDataPoint);
            nutrientVolatility.Add(nutrientVolatilityDataPoint);
            humus.Add(humusDataPoint);
            organicMatter.Add(organicMatterDataPoint);
            aggregateStability.Add(aggregateStabilityDataPoint);

            time++;
        }
    }
}
