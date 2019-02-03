using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.GameEngine {
    public class Linear : SoilFunction {
        private float gradient;
        private float intercept;

        public Linear(float gradient, float intercept) {
            this.gradient = gradient;
            this.intercept = intercept;
        }

        public override float f(float t) {
            return gradient * t + intercept;
        }
    }
}
