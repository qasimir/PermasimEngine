using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SoilNutrientManager : NutrientManager{

    public SoilNutrientManager(String name) : base(name) {

    }

    public float amount;
    public float amountAvailable;
    // (only used for water for the time being)
    public float capacity;
    public float absorptionRate;
    public float atmosphericRemovalRate; // evaporation through wind in the case of water
    public float drainageRemovalRate; // drainage

}

