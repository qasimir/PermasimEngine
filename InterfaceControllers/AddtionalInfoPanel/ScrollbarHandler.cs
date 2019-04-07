using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHandler : MonoBehaviour {

    private static Scrollbar scrollBar;

	// Use this for initialization
	void Start () {
        scrollBar = GetComponent<Scrollbar>();
        resetScrollbarToTop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void resetScrollbarToTop() {
        scrollBar.value = 1;
    }
}
