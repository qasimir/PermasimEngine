using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour{

    [SerializeField]
    private Text buttonText;

    public void setText(string text) {
        this.buttonText.text = text;
    }
    public Text getText() {
        return buttonText;
    }

    public void OnClick() {
        string currentTask = TaskHandler.getActiveTask();
        TaskHandler.setActiveTask(currentTask + "_" +);
        TaskHandler.executeTaskIfCriteriaSelected(new Material(buttonText.text));
        
    }

}

