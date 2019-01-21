using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SoilNutrientManager : NutrientManager{

    public SoilNutrientManager(String name) : base(name) {

    }

    public float amount;
    public float amountAvailable;
    public float capacity;
    public float absorption;
    public float atmosphericRemovalRate;
    public float drainageRemovalRate;

}

