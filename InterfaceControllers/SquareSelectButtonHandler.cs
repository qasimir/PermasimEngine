using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareSelectButtonHandler : MonoBehaviour {

    public Button button;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(SetStateToSelect);
	}
	
	// Update is called once per frame
	void SetStateToSelect() {
        StateHandler.STATE = StateHandler.SelectTerrainState;
	}
}
