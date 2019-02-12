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

    private bool primaryMouseClicked = true;
    private float raiseLowerStrength = 0.03f;
    private int raiseLowerBrushWidth = 20;
    private TerrainSelection terrainSelection = new TerrainSelection();


    void Start() {
        cam = Camera.main;
        terrain = Terrain.activeTerrain;
        terrainTools = GetComponent<TerrainTools>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            primaryMouseClicked = true;
            Debug.Log(StateHandler.STATE);
            MethodInfo methodInfo = this.GetType().GetMethod(StateHandler.STATE, BindingFlags.NonPublic | BindingFlags.Instance);
            castRays(0.03f, methodInfo);

        } else if (Input.GetMouseButton(1)) {
            primaryMouseClicked = false;
            Debug.Log(StateHandler.STATE);
            MethodInfo methodInfo = this.GetType().GetMethod(StateHandler.STATE, BindingFlags.NonPublic | BindingFlags.Instance);
            castRays(-0.03f, methodInfo);

        } 
    }

    private void castRays(float strength, MethodInfo methodInfo) {
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

        float terrainDataSizeX = terrain.terrainData.size.x;
        float terrainDataSizeZ = terrain.terrainData.size.z;

        int mouseX = (int)((point.x * heightMapWidth) / terrainDataSizeX);
        int mouseZ = (int)((point.z * heightMapHeight) / terrainDataSizeZ);

        float strength = primaryMouseClicked?(raiseLowerStrength): (-1*raiseLowerStrength);
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
                    (XMaximum - XMinimum)/2, 
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
            terrainSelection.startPoint = point;
            Debug.Log("Starting Point: " + point);
        } else {
            terrainSelection.endPoint = point;
            Debug.Log("Ending Point: " + point);
        }
    }
}