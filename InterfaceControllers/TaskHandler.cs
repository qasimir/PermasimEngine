using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.GameEngine;
using System.Reflection;
using UnityEngine.UI;

public class TaskHandler : MonoBehaviour {
    private static TerrainSelection landSelected = null;
    private static string taskSelected = "Task";
    private static Material materialSelected;
    private static TaskHandler instance;

    public static Text taskSelectedText;


    public static void executeTaskIfCriteriaSelected(string Task) {
        taskSelected = Task;
        executeTaskIfCriteriaSelected();
    }

    public static void executeTaskIfCriteriaSelected(TerrainSelection terrainSelection) {
        landSelected = terrainSelection;
        executeTaskIfCriteriaSelected();
    }

    public static void executeTaskIfCriteriaSelected(Material material) {
        materialSelected = material;
        executeTaskIfCriteriaSelected();
    }

    private static void executeTaskIfCriteriaSelected() {
        bool readyToPerformTask =
            taskSelected != null &&
            landSelected != null &&
            materialSelected != null;

            alterTaskDisplay();
        
        if (readyToPerformTask) {
            //use reflection to run the method associated with the text;
            Type type = instance.GetType();
            MethodInfo method = type.GetMethod(taskSelected.Replace(" ", ""));
            method.Invoke(instance, null);
            resetState();
            
        }
    }

    private static void resetState() {
        taskSelected = "Task";
        landSelected = null;
        materialSelected = null;
        AdditionalInfoSelectHandler.closePanel();
    }

    private static void alterTaskDisplay() {
        if (taskSelected != null || !taskSelected.Equals("Tasks")) {
            taskSelectedText.text = taskSelected;
        } else {
            taskSelectedText.text = "";
        }
    }

    private void DigSoil() {

    }

    private void Plant() {
        // calculate the number of crops required to fill the space, and fill in the coordinates
        PlantFactory plantFactory = new PlantFactory();
        Plant plant = plantFactory.getPlantType(materialSelected.name);
        float plantingDistance = plant.plantingDistance;
        
        double landSelectionLength = Mathf.Abs(landSelected.corner1.x - landSelected.startPointTerrain.x);
        double landSelectionWidth = Mathf.Abs(landSelected.corner2.y - landSelected.startPointTerrain.y);
        
        for (float w = 0; w < landSelectionWidth; w+=plantingDistance) {
            for (float l = 0; l < landSelectionWidth; l += plantingDistance) {
                plantFactory.createPlant(materialSelected.name);
            }
        }
        // print the crops to the screen
        // add crops to the backend
    }

    private void Mulch() {

    }

    private void RemoveTopsoil() {

    }

    private void AddTopsoil() {

    }

    void Start() {
        taskSelectedText = GetComponent<Text>();
    }
    void Update() {

    }
    public static string getActiveTask() {
        return taskSelected;
    }
    public static void setActiveTask(string task) {
        taskSelected = task;
    }

    public static Material getActiveMaterial() {
        return materialSelected;
    }
    public static void setActiveMaterial(Material material) {
        materialSelected = material;
    }


}

