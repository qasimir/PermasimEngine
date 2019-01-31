using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TimeEvolver {

    public void evolveTime(float timeInDays = 7 ) {
        // generate weather events (rain/wind etc.)

        for (int x = 0; x < WorldMap.mapWidth; x++) {
            for (int y = 0; y < WorldMap.mapHeight; y++) {
                Segment segment = WorldMap.instance.segments[x, y];
                // evolve the plants
                evolvePlants(ref segment.plants);
                // evolve the soil
                evolveSoil(ref segment.soilProfile);
            }

        }
    }
    private void evolvePlants(ref List<Plant> plants) {
        for (int i=0;i<plants.Count();i++) {
            Plant plant = plants[i];
            PlantProcessor.processPlant(ref plant);
        }
    }

    private void evolveSoil(ref SoilProfile soilProfile) {
        for (int i = 0;i<soilProfile.soilHorizons.Count(); i++) {
            SoilHorizon soilHorizon = soilProfile.soilHorizons[i];
            SoilHorizonProcessor.processSoil(ref soilHorizon);
        }
    }


}

