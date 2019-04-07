using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {

    [SerializeField]
    private Text buttonText;

    void Start() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void setText(string text) {
        this.buttonText.text = text;
    }
    public Text getText() {
        return buttonText;
    }

    public void OnClick() {
        string currentTask = TaskHandler.getActiveTask();
        TaskHandler.executeTaskIfCriteriaSelected(new Material(buttonText.text));
        AdditionalInfoSelectHandler.closePanel();
        print(TaskHandler.getActiveMaterial().name);
        
    }

}

