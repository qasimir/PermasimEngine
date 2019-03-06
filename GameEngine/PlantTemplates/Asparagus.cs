using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Asparagus : Vegetable {

    public Asparagus(Soil soil) {
        Initialize(soil);
    }

    private void Initialize(Soil soil) {
        this.name = "Asparagus";
        this.age = 0;
        this.maxMaturity = 156; //3 years
        this.plantingDistance = 30; // in cm
        this.size = 0;
        this.maxSize = 30; // this is a guess
        this.health = 1; // optimal health
        this.heavinessOptimal = 0.2f;
        this.temperatureLowerLimit = -45; // from usda hardiness zone 2
        this.temperatureOptimal = 25; // optimum for photosynthesis
        this.temperatureUpperLimit = 43; // no photosynthesis past this 
        float fieldCapacity = soil.getFieldCapacity();
        float saturationPoint = soil.getSaturationPoint();
        float wiltingPoint = soil.getWiltingPointEffective();
        this.waterOptimal = fieldCapacity;
        this.waterUpperLimit = ((saturationPoint - fieldCapacity) / 2) + fieldCapacity;
        this.waterLowerLimit = wiltingPoint;
    }
}
