using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Simulation {
    public class SoilNutrientManager : Simulation.NutrientManager {

        public SoilNutrientManager(String name) : base(name) {

        }

        public float amount;
        private float amountAvailableFactor;

        // (only used for water for the time being)
        public float capacity;
        public float absorptionRate;
        public float atmosphericRemovalRate; // evaporation through wind in the case of water
        public float drainageRemovalRate; // drainage

        // miscelleneous parameters
        public float postDiggingAvailability;

        public void setAmountAvailableFactor(float amountAvailable) {
            if (amountAvailable > 1) {
                amountAvailable = 1;
            } else {
                this.amountAvailableFactor = amountAvailable;
            }
        }

        public float getAmountAvailableFactor() {
            return amountAvailableFactor;
        }



    }
}

