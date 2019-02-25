using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Simulation {
    public class OrganicMatter {
        public Dictionary<string, SoilNutrientManager> soilNutrientManagers;

        public OrganicMatter() {
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
