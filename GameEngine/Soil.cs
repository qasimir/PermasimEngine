using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameEngine {
    public class Soil {
        private float currentQuality { get; set; } // between 1 and 0
        private float baselineQuality { get; set; } // between 1 and 0
        private float heaviness { get; set; }
        private float water { get; set; }
        private float soilTemp { get; set; }
        private List<SoilEffect> soilEffects;

        public void evolveSoil() {
            foreach  (SoilEffect soilEffect in soilEffects) {
                // here we multiply by the baseline quality to normalize
                currentQuality += baselineQuality * soilEffect.getModifier(); 
                soilEffect
            }


        }

        public void alterBaselineQuality(float newValue) {
            baselineQuality = newValue;

        }

        public void dig() {
            // digging quality modifier = ae^-bx - ce^-dx + f
            float a = Parameters.diggingBonusAmplitude;
            float b = Parameters.diggingBonusDecay;
            float c = Parameters.diggingDetrimentAmplitude;
            float d = Parameters.diggingDetrimentDecay;

            SoilFunction bonus = new Exponential(a, b);
            SoilFunction detriment = new Exponential(-c, d);
            List<SoilFunction> terms = new List<SoilFunction>{bonus, detriment};
            SoilEffect effectOfDigging = new SoilEffect(terms);
            soilEffects.Add(effectOfDigging);
            
        }

        public void addWater() {

        }

        public void addMulch() {

        }

        public void addHumus() {

        }

        internal float getCurrentQuality() {
            return currentQuality;
        }
        internal float getHeaviness() {
            return heaviness;
        }
        internal float getWater() {
            return water;
        }
        internal float getSoilTemp() {
            return soilTemp;
        }

    }
}
