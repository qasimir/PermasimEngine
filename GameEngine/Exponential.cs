using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameEngine {
    internal class Exponential : SoilFunction {
        private float ampl;
        private float decay;

        public Exponential(float ampl, float decay) {
            this.ampl = ampl;
            this.decay = decay;
        }

        public override float f(float t) {
            return ampl * Mathf.Exp(t * ampl) ;
        }
    }
}
