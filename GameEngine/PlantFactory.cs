using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlantFactory {
    private List<Plant> plantTypes { get; set; }

    public PlantFactory() {
        plantTypes = new List<Plant>();
        plantTypes.Add(new Vegetable("Asparagus"));
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
        plantTypes.Add(new Vegetable("Zucchini"));
    }

    public List<Plant> getPlantTypes() {
        return plantTypes;
    }

    public List<Plant> createPlant(string name) {
        Plant plantTemplate = plantTypes.Where(plantName => plantName.Equals(name)).First();
    }

    public void initializePlantTemplates() {

    }


}
