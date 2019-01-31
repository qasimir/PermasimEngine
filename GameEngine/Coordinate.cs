﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.GameEngine {
    public class Coordinate {
        public int x;
        public int y;
        private List<Plant> plants;
        private Soil soil;
        private float AirTemp;

        public void evolveTime() {
            foreach (Plant plant in plants) {
                plant.grow(ref soil, AirTemp);
            }
        }
    }
}
