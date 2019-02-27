using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalInfoSelectHandler : MonoBehaviour {

    public Canvas rootCanvas;
    public Image content;

    private static bool panelShouldBeOpen = false;
    private static bool printedButtons = false;
    private List<GameObject> currentButtons = new List<GameObject>();



    // Use this for initialization
    void Start () {
        rootCanvas = GetComponent<Canvas>();
        rootCanvas.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        string activeTask = TaskHandler.getActiveTask();
        if (activeTask.Equals("Plant") && !printedButtons) {
            destroyPreviousButtons();
            openPanel();
            setButtonsAsPrinted();
            PlantFactory plantFactory = new PlantFactory();
            currentButtons = ButtonListController.Instance.populatePlantList();
        }
        rootCanvas.enabled = panelShouldBeOpen;
    }

    private void destroyPreviousButtons() {
        if (currentButtons.Count > 0) {
            foreach (GameObject button in currentButtons) {
                Destroy(button.gameObject);
            }
            currentButtons.Clear();
        }
    }

    public static void openPanel() {
        panelShouldBeOpen = true;
        ScrollbarHandler.resetScrollbarToTop();
    }

    public static void closePanel() {
        panelShouldBeOpen = false;
    }

    public static void unSetButtonsAsPrinted() {
        printedButtons = false;
    }

    public static void setButtonsAsPrinted() {
        printedButtons = true;
    }

}
