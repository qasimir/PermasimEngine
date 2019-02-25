using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Simulation {
    public class MulchLayer {
        public Dictionary<string, SoilNutrientManager> soilNutrientManagers;
        public float volume;

        public MulchLayer() {
            soilNutrientManagers = new Dictionary<string, SoilNutrientManager>();
            soilNutrientManagers.Add("carbon", new SoilNutrientManager("carbon"));
            soilNutrientManagers.Add("nitrogen", new SoilNutrientManager("nitrogen"));
            soilNutrientManagers.Add("phosphorus", new SoilNutrientManager("phosphorus"));
            soilNutrientManagers.Add("potassium", new SoilNutrientManager("potassium"));
            soilNutrientManagers.Add("traceMinerals", new SoilNutrientManager("traceMinerals"));
            soilNutrientManagers.Add("water", new SoilNutrientManager("water"));
        }

    }
}

