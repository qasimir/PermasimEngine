using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour {

    public Terrain terrain;

    void Start() {
        terrain = Terrain.activeTerrain;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                transform.position = hit.point;
            }
        }
    }
}
