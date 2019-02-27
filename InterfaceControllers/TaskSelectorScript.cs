using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskSelectorScript : MonoBehaviour, IPointerClickHandler{


    Dropdown dropdown;
    Dictionary<int,string> entries = new Dictionary<int, string> {
    { 0, "Tasks" },
    { 1, "Dig Soil" },
    { 2, "Plant" },
    { 3, "Mulch"},
    { 4, "Remove Topsoil"},
    { 5, "Add Topsoil"}
    };

    // Use this for initialization
    void Start () {
		dropdown = GetComponent<Dropdown>();
        dropdown.itemText.text = "Tasks";

        dropdown.ClearOptions();

        for (int i =0; i< entries.Count;i++) {
            Dropdown.OptionData option = new Dropdown.OptionData();
            string value;
            entries.TryGetValue(i, out value);
            option.text = value;
            dropdown.options.Add(option);
        }

        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });

    }

    private void DropdownValueChanged(Dropdown dropdown) {
        int selectedIndex = dropdown.value;
        string selectedText = dropdown.options[selectedIndex].text;
        AdditionalInfoSelectHandler.unSetButtonsAsPrinted();
        TaskHandler.executeTaskIfCriteriaSelected(selectedText);
    }

    public void OnPointerClick(PointerEventData eventData) {
        
    }
}
