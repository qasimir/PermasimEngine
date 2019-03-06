using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SoilEffect {
    private string name;
    private int t_elapsed;
    private List<SoilFunction> soilModifierFunctions;
    private List<SoilFunction> soilBaselineFunctions;
    private static readonly float EFFECTLESS_FACTOR = 0.0001f;

    // Constructors
    //-------------------------------
    public SoilEffect(int t_elapsed, List<SoilFunction> soilModifierFunctions) {
        this.t_elapsed = t_elapsed;
        this.soilModifierFunctions = soilModifierFunctions;
    }
    public SoilEffect(List<SoilFunction> soilModifierFunctions) {
        this.t_elapsed = 0;
        this.soilModifierFunctions = soilModifierFunctions;
    }
    public SoilEffect(int t_elapsed, List<SoilFunction> soilModifierFunctions, List<SoilFunction> soilBaselineFunctions) {
        this.t_elapsed = t_elapsed;
        this.soilModifierFunctions = soilModifierFunctions;
        this.soilBaselineFunctions = soilBaselineFunctions;
    }
    public SoilEffect(List<SoilFunction> soilModifierFunctions, List<SoilFunction> soilBaselineFunctions) {
        this.t_elapsed = 0;
        this.soilModifierFunctions = soilModifierFunctions;
        this.soilBaselineFunctions = soilBaselineFunctions;
    }
    public SoilEffect(int t_elapsed, SoilFunction soilModifierFunction) {
        this.t_elapsed = t_elapsed;
        this.soilModifierFunctions = new List<SoilFunction> { soilModifierFunction };
    }
    public SoilEffect(SoilFunction soilModifierFunction) {
        this.t_elapsed = 0;
        this.soilModifierFunctions = new List<SoilFunction> { soilModifierFunction };
    }
    public SoilEffect(int t_elapsed, SoilFunction soilModifierFunction, SoilFunction soilBaselineFunction) {
        this.t_elapsed = t_elapsed;
        this.soilModifierFunctions = new List<SoilFunction> { soilModifierFunction };
        this.soilBaselineFunctions = new List<SoilFunction> { soilBaselineFunction };
    }
    public SoilEffect(SoilFunction soilModifierFunction, SoilFunction soilBaselineFunction) {
        this.t_elapsed = 0;
        this.soilModifierFunctions = new List<SoilFunction> { soilModifierFunction };
        this.soilBaselineFunctions = new List<SoilFunction> { soilBaselineFunction };
    }

    public float getModifierResult() {
        float value = 0;
        foreach (SoilFunction soilFunction in soilModifierFunctions) {
            value += soilFunction.f(t_elapsed);
        }
        return value;
    }
    //-------------------------------

    public float getBaselineResult() {
        float value = 0;
        foreach (SoilFunction soilFunction in soilBaselineFunctions) {
            value += soilFunction.f(t_elapsed);
        }
        return value;
    }

    // this method is used to prune dead effects. 
    // All soil effects have a lifetime, and dead ones should be removed
    public bool needsCleaning() {
        bool valid = false;
        foreach (SoilFunction soilFunction in soilModifierFunctions) {
            if (soilFunction.f(t_elapsed) > EFFECTLESS_FACTOR) {
                valid = true;
            }
        }
        return valid;
    }

    public void incrementTimeElapsed() {
        t_elapsed++;
    }

    public void assignName(string name) {
        this.name = name;
    }
}

