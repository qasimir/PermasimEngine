using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.GameEngine {
    class SoilEffect {
        private int t_elapsed;
        private List<SoilFunction> soilFunctions;
        private static readonly float EFFECTLESS_FACTOR = 0.0001f;

        public SoilEffect(int t_elapsed, List<SoilFunction> soilFunctions) {
            this.t_elapsed = t_elapsed;
            this.soilFunctions = soilFunctions;
        }
        public SoilEffect(List<SoilFunction> soilFunctions) {
            this.t_elapsed = 0;
            this.soilFunctions = soilFunctions;
        }

        public float getModifier() {
            float value = 0;
            foreach (SoilFunction soilFunction in soilFunctions) {
                value += soilFunction.f(t_elapsed);
            }
            return value;
        }

        // this method is used to prune dead effects. 
        // All soil effects have a lifetime, and dead ones should be removed
        public bool needsCleaning() {
            bool valid = false;
            foreach (SoilFunction soilFunction in soilFunctions) {
                if (soilFunction.f(t_elapsed) > EFFECTLESS_FACTOR) {
                    valid = true;
                }
            }
            return valid;
        }

        public void incrementTimeElapsed() {
            t_elapsed++;
        }
    }
}
