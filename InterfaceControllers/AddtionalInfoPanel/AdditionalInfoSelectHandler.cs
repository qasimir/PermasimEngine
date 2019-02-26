using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalInfoSelectHandler : MonoBehaviour {

    public Canvas rootCanvas;
    public Image content;

    public static bool menuOpen = true;
    private bool printedButtons = false;
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
            rootCanvas.enabled = menuOpen;
            PlantFactory plantFactory = new PlantFactory();
            currentButtons = ButtonListController.Instance.populatePlantList();
            printedButtons = true;
        }	

	}

    private void destroyPreviousButtons() {
        if (currentButtons.Count > 0) {
            foreach (GameObject button in currentButtons) {
                Destroy(button.gameObject);
            }
            currentButtons.Clear();
        }
    }
}
