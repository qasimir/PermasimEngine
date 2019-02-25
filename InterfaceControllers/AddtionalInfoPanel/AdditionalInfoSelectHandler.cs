﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalInfoSelectHandler : MonoBehaviour {

    public Canvas rootCanvas;
    public Image content;

    // Use this for initialization
    void Start () {
        rootCanvas = GetComponent<Canvas>();
        rootCanvas.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        string activeTask = TaskHandler.getActiveTask();

        if (activeTask.Equals("Plant")) {
            rootCanvas.enabled = true;
            PlantFactory plantFactory = new PlantFactory();
            ButtonListController.Instance.populatePlantList();
        }	

	}
}
