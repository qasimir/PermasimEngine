using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MouseHandler : MonoBehaviour {

    private Camera cam;
    private Terrain terrain;
    private TerrainTools terrainTools;
    public GUIStyle MouseDragSkin;

    private bool mouseDragged = true;
    private float raiseLowerStrength = 0.03f;
    private int raiseLowerBrushWidth = 20;

    private TerrainSelection terrainSelection = new TerrainSelection();


    void Start() {
        cam = Camera.main;
        terrain = Terrain.activeTerrain;
        terrainTools = GetComponent<TerrainTools>();
    }

    void Update() {
        mouseDragged = false;
        if (Input.GetMouseButton(0)) {
            Debug.Log(StateHandler.STATE);
            MethodInfo methodInfo = this.GetType().GetMethod(StateHandler.STATE, BindingFlags.NonPublic | BindingFlags.Instance);
            castRays(methodInfo);

        } else if (Input.GetMouseButton(1)) {
            
            Debug.Log(StateHandler.STATE);
            MethodInfo methodInfo = this.GetType().GetMethod(StateHandler.STATE, BindingFlags.NonPublic | BindingFlags.Instance);
            castRays(methodInfo);

        } 
    }

    private void castRays(MethodInfo methodInfo) {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 100, false);
            object[] parameters = new object[] { hit.point };
            methodInfo.Invoke(this, parameters);
        }
    }

    private void RaiseLowerTerrain(Vector3 point) {

        int heightMapWidth = terrain.terrainData.heightmapWidth;
        int heightMapHeight = terrain.terrainData.heightmapHeight;

        int mouseX;
        int mouseZ;

        TerrainTools.raycastedVectorToTerrainCoord(point,"heightmap",out mouseX,out mouseZ);

        float strength = Input.GetMouseButton(0) ? (raiseLowerStrength) : (-1 * raiseLowerStrength);
        int XMinimum = (mouseX - raiseLowerBrushWidth) > 0 ? (mouseX - raiseLowerBrushWidth) : 0;
        int XMaximum = (mouseX + raiseLowerBrushWidth) < heightMapWidth ? (mouseX + raiseLowerBrushWidth) : heightMapWidth;
        int ZMinimum = (mouseZ - raiseLowerBrushWidth) > 0 ? (mouseZ - raiseLowerBrushWidth) : 0;
        int ZMaximum = (mouseZ + raiseLowerBrushWidth) < heightMapHeight ? (mouseZ + raiseLowerBrushWidth) : heightMapHeight;

        float[,] heights = terrain.terrainData.GetHeights(XMinimum, ZMinimum, XMaximum - XMinimum, ZMaximum - ZMinimum);


        for (int x = 0; x < XMaximum - XMinimum; x++) {
            for (int z = 0; z < ZMaximum - ZMinimum; z++) {
                heights[z, x] += terrainTools.cosineWeighting(
                    (float)x,
                    (float)z,
                    (XMaximum - XMinimum) / 2,
                    (ZMaximum - ZMinimum) / 2,
                    raiseLowerBrushWidth,
                    strength) * Time.deltaTime;
            }
        }

        terrain.terrainData.SetHeights(XMinimum, ZMinimum, heights);
    }

    private void SelectTerrain(Vector3 point) {

        if (Input.GetMouseButtonDown(0)) {
            terrainSelection = new TerrainSelection();
            terrainSelection.startPointTerrain = point;
            terrainSelection.startPointMouse = Input.mousePosition;
            Debug.Log("Starting Point: " + point);
        } else {
            mouseDragged = true;
            terrainSelection.endPointTerrain = point;
            terrainSelection.endPointMouse = Input.mousePosition;
            float BoxLeft = Input.mousePosition.x;
            float BoxTop = Input.mousePosition.y;
            Debug.Log(BoxLeft + "  " + BoxTop);
        }
    }

    private void Default(Vector3 point) {

    }

    void OnGUI() {
        if (mouseDragged) {
            float x = terrainSelection.startPointMouse.x;
            float y = Screen.height - terrainSelection.startPointMouse.y;
            float width = terrainSelection.endPointMouse.x - x;
            float height = Screen.height - terrainSelection.endPointMouse.y - y;
            GUI.Box(new Rect(x, y, width, height), "", MouseDragSkin);
        }
        
    }
}