using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoilHorizon : MonoBehaviour {

    // fundamental varibles
    public float sandPercent;
    public float clayPercent;
    public float siltPercent;
    public float humusPercent;

    public Dictionary<string, SoilNutrientManager> soilNutrientManagers;

    public float organicMatter; // to be decayed

    // temperature related
    public float temperature;
    public float thermalMass;

    // other variables
    public float porosity;
    public float compactability;
    public float decompositionRate;
    public float erosionRate;
    public float phResistance;

    public float upperBound;
    public float lowerBound;

    public SoilHorizon() {
        soilNutrientManagers = new Dictionary<string, SoilNutrientManager>();
        soilNutrientManagers.Add("nitrogen", new SoilNutrientManager("nitrogen"));
        soilNutrientManagers.Add("phosphorus", new SoilNutrientManager("phosphorus"));
        soilNutrientManagers.Add("potassium", new SoilNutrientManager("potassium"));
        soilNutrientManagers.Add("traceMinerals", new SoilNutrientManager("traceMinerals"));
        soilNutrientManagers.Add("water", new SoilNutrientManager("water"));
    }

    public void calibrate() {

    }


}

