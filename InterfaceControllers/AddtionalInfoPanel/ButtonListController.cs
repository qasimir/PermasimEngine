using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ButtonListController : Singleton<ButtonListController> {

    [SerializeField]
    private GameObject buttonTemplate;

    private ButtonListController privateInstance = null;
   

    public void populatePlantList() {
        PlantFactory plantFactory = new PlantFactory();
        foreach (Plant P in plantFactory.getPlantTypes()) {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().setText(P.name);
            button.GetComponent<ButtonListButton>().getText().fontSize = 5;
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }


}

