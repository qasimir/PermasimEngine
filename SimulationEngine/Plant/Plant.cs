using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



namespace Simulation {
    public class Plant {


        public Dictionary<string, PlantNutrientManager> plantNutrientManagers;

        public float rootDepth;
        public float rootDepthPercentTotal;
        public float rootWidth;
        public float rootWidthPercentTotal;
        public float foliageHeight;
        public float foliageHeightPercentTotal;
        public float foliageWidth;
        public float foliageWidthPercentTotal;
        public float totalSize;

        public Segment segment; // the segment of land underneath the plant

        public int age;
        public int maturityTime;
        public int maxLifeTime;
        public float maxSize;
        public float currentYeild;
        public bool isAlive;

        // The optimally sized plant will be massive. 
        // Thus we calculate the growth curve under optimal conditions, and take a fraction of that.
        public float growthFactor = 0;
        public float percentSizeOfOptimal = 0;

        public Plant(Segment segment) {
            this.segment = segment;

            plantNutrientManagers = new Dictionary<string, PlantNutrientManager>();

            plantNutrientManagers.Add("nitrogen", new PlantNutrientManager("nitrogen"));
            plantNutrientManagers.Add("phosphorus", new PlantNutrientManager("phosphorus"));
            plantNutrientManagers.Add("potassium", new PlantNutrientManager("potassium"));
            plantNutrientManagers.Add("traceMinerals", new PlantNutrientManager("traceMinerals"));
            plantNutrientManagers.Add("water", new PlantNutrientManager("water"));

        }
    }
}

