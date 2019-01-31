using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.GameEngine {
    public class Parameters {


        public static readonly float e = 2.71828f;
        // digging quality modifier = ae^-bx - ce^-dx + f
        // we want this to be 0.2 above the baseline. Found this out with Desmos
        public static readonly float diggingBonusAmplitude = 0.9f; // = a-c+f
        // we want this to be 0.3 below the baseline. Found this out with Desmos
        public static readonly float diggingDetrimentAmplitude = 0.7f; // = ( ae^(-b/(b-d)) - ce^(-d(b-d)) ) (ab/dc) + f

        // we want this to reduce to 1/8 over 1/2 of a year (2 seasons) = 0.07997852
        public static readonly float diggingBonusDecay = 0.08f; // = (-1/b)*ln(1/8)
        // we want this to reduce to 1/8 over 2 years (8 seasons) = 0.01999463
        public static readonly float diggingDetrimentDecay = 0.02f; // = (-1/d)*ln(1/8)


    }
}
