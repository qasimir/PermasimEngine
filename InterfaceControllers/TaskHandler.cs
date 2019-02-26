using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.GameEngine;
using System.Reflection;
using UnityEngine.UI;

public class TaskHandler : MonoBehaviour {
    private static List<Coordinate> landSelected = null;
    private static string taskSelected = "Task";
    private static Material materialSelected;
    private static TaskHandler instance;

    public static Text taskSelectedText;


    public static void executeTaskIfCriteriaSelected(string Task) {
        taskSelected = Task;
        executeTaskIfCriteriaSelected();
    }

    public static void executeTaskIfCriteriaSelected(List<Coordinate> coordinate) {
        landSelected = coordinate;
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
        AdditionalInfoSelectHandler.menuOpen = true;
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

