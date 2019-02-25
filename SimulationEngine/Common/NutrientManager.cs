using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Simulation {
    public class NutrientManager : MonoBehaviour {
        string nutrientName;

        public NutrientManager(string name) {
            this.nutrientName = name;
        }
    }
}

