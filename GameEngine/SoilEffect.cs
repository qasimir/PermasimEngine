using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.GameEngine {
    class SoilEffect {
        private int t_elapsed;
        private List<SoilFunction> soilFunctions;

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

        public void incrementTimeElapsed() {
            t_elapsed++;
        }
    }
}
