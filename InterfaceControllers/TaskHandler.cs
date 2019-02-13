using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.GameEngine;
using Material = Assets.GameEngine.Material;
using System.Reflection;

public class TaskHandler {
    private static List<Coordinate> landSelected = null;
    private static string taskSelected = null;
    private static Material materialSelected = null;
    private static TaskHandler instance = new TaskHandler();

    private TaskHandler() {}

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

        if (readyToPerformTask) {
            //use reflection to run the method associated with the text;
            Type type = instance.GetType();
            MethodInfo method = type.GetMethod(taskSelected);
            method.Invoke(instance, null);
            taskSelected = null;
            landSelected = null;
            materialSelected = null;
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




}

