using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class PlantFactory : MonoBehaviour {
    public List<Plant> plantTypes { get; set; }
    public Asparagus asparagus;


    public PlantFactory() {
        plantTypes = new List<Plant>();
        GameObject asparagusGO = transform.Find("Asparagus").gameObject;
        print(asparagusGO);
        this.asparagus = new Asparagus(asparagusGO);
        /*
        plantTypes.Add(new Vegetable("Aubergine"));
        plantTypes.Add(new Vegetable("Basil"));
        plantTypes.Add(new Vegetable("Broad Bean"));
        plantTypes.Add(new Vegetable("Climbing Bean"));
        plantTypes.Add(new Vegetable("Beetroot"));
        plantTypes.Add(new Vegetable("Bok Choy"));
        plantTypes.Add(new Vegetable("Broccoli"));
        plantTypes.Add(new Vegetable("Cabbage"));
        plantTypes.Add(new Vegetable("Capsicum"));
        plantTypes.Add(new Vegetable("Carrot"));
        plantTypes.Add(new Vegetable("Celery"));
        plantTypes.Add(new Vegetable("Chicory"));
        plantTypes.Add(new Vegetable("Cucumber"));
        plantTypes.Add(new Vegetable("Garlic"));
        plantTypes.Add(new Vegetable("Leek"));
        plantTypes.Add(new Vegetable("Lettuce"));
        plantTypes.Add(new Vegetable("Mustard"));
        plantTypes.Add(new Vegetable("Pea"));
        plantTypes.Add(new Vegetable("Potato"));
        plantTypes.Add(new Vegetable("Pumpkin"));
        plantTypes.Add(new Vegetable("Silverbeet"));
        plantTypes.Add(new Vegetable("Spinach"));
        plantTypes.Add(new Vegetable("Sweet Corn"));
        plantTypes.Add(new Vegetable("Zucchini"));*/
    }

    public List<Plant> getPlantTypes() {
        return plantTypes;
    }

    public Plant getPlantType(string name) {
        Type plantFactoryType = this.GetType();
        return (Plant) plantFactoryType.GetField(name).GetValue(this);
    }

    public void createPlant(string name, Soil soil = null, float xTerrain = -1, float yTerrain = -1) {
        Plant plant = getPlantType(name);
        plant.PlantInSoil(soil);
        Instantiate(plant.gameObject,new Vector3(xTerrain,0,yTerrain),Quaternion.identity);
    }

    public void createPlant(Plant plant, Soil soil = null, float xTerrain = -1, float yTerrain = -1) {
        plant.PlantInSoil(soil);
        Instantiate(plant.gameObject, new Vector3(xTerrain, 0, yTerrain), Quaternion.identity);
    }

    public void initializePlantTemplates() {

    }


}
