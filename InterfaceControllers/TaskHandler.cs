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
    private static Material materialSelected = null;
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
            taskSelected = null;
            landSelected = null;
            materialSelected = null;
        }
    }

    private static void alterTaskDisplay() {
        if (taskSelected != null || !taskSelected.Equals("Tasks")) {
            taskSelectedText.text = taskSelected;
        } else {
            taskSelectedText.text = "";
        }
    }

    public static string getActiveTask() {
        return taskSelected;
    }
    public static void setActiveTask(string task) {
        taskSelected = task;
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



}

