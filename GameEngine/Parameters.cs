using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    // this number comes from the fact that in the game world, the one coord point is roughly (by eye) measured to be 30x30 cm. 
    // The growth depth is ~60 cm, and assuming topsoil with 15% humus is as good as it will get, 0.008m^3 of humus per 
    //0.6x0.3x0.3 m section of soil will raise the quality from 0 to 1.
    public static readonly float humusVolumeToSoilQuality = 1 / 0.008f;

    // from https://www.tandfonline.com/doi/abs/10.1080/1065657X.2004.10702206
    // "Reductions in mass averaged 19.4% of initial mass and ranged from 11.5% to 31.4%."
    public static readonly float mulchToHumusVolumeReductionFactor = 0.8f;

    // 1%. Dunno if this is a good value, I just made it up.
    public static readonly float soilDestructionFromDigging = -0.01f;

    // I assume it takes about a year for all organic materials to be finally digested. therefore, each week, 4% of the mulch is decayed.
    public static readonly float mulchDecayConstant = 0.04f; // = (-1/d)*ln(1/8)


}
