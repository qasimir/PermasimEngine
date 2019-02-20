using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MouseHandler : MonoBehaviour {

    public GUIStyle mouseDragSkin;
    public GameObject selectionFlag;
    public GameObject carrot;
    public float defaultRaiseLowerStrength = 0.03f;
    public int defaultRaiseLowerBrushWidth = 20;

    private Camera cam;
    private Terrain terrain;
    private TerrainTools terrainTools;

    private bool mouseDraggedTerrainSelect = true;
    

    private TerrainSelection terrainSelection = new TerrainSelection();


    void Start() {
        cam = Camera.main;
        terrain = Terrain.activeTerrain;
        terrainTools = GetComponent<TerrainTools>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.T)) {
            Instantiate(selectionFlag, new Vector3(96.8f, 0, 245.18f), Quaternion.identity);
            Instantiate(carrot, new Vector3(96.8f, 0, 246.18f), Quaternion.identity);
        }

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) {
            Debug.Log(StateHandler.STATE);
            MethodInfo methodInfo = this.GetType().GetMethod(StateHandler.STATE, BindingFlags.NonPublic | BindingFlags.Instance);
            castRays(methodInfo);
        } else {
            mouseDraggedTerrainSelect = false;
        }
        

    }

    private void castRays(MethodInfo methodInfo) {
        object[] parameters = new object[] { castRays(Input.mousePosition) };
        methodInfo.Invoke(this, parameters);
    }

    private Vector3 castRays(Vector3 castVector) {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(castVector);
        if (Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 100, false);
            return hit.point;
        }
        return new Vector3();
    }

    private void RaiseLowerTerrain(Vector3 point) {

        float raiseLowerStrength = defaultRaiseLowerStrength;
        int raiseLowerBrushWidth = defaultRaiseLowerBrushWidth;
        if (Input.GetMouseButton(1)) {
            raiseLowerStrength = - defaultRaiseLowerStrength;
        } 
        

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
        } else if (Input.GetMouseButton(0)) {
            mouseDraggedTerrainSelect = true;
            terrainSelection.endPointTerrain = point;
            terrainSelection.endPointMouse = Input.mousePosition;
            float BoxLeft = Input.mousePosition.x;
            float BoxTop = Input.mousePosition.y;
        } else if (Input.GetMouseButtonUp(0)) {

            Vector3 corner1 = castRays(new Vector3(terrainSelection.startPointMouse.x, terrainSelection.endPointMouse.y, 0));
            Vector3 corner2 = castRays(new Vector3(terrainSelection.endPointMouse.x, terrainSelection.startPointMouse.y, 0));

            terrainSelection.corner1 = corner1;
            terrainSelection.corner2 = corner2;

            Instantiate(selectionFlag, terrainSelection.startPointTerrain, Quaternion.identity);
            Instantiate(selectionFlag, terrainSelection.endPointTerrain, Quaternion.identity);
            Instantiate(selectionFlag, corner1, Quaternion.identity);
            Instantiate(selectionFlag, corner2, Quaternion.identity);
        }
    }

    private void Default(Vector3 point) {

    }

    void OnGUI() {
        if (mouseDraggedTerrainSelect) {
            float x = terrainSelection.startPointMouse.x;
            float y = Screen.height - terrainSelection.startPointMouse.y;
            float width = terrainSelection.endPointMouse.x - x;
            float height = Screen.height - terrainSelection.endPointMouse.y - y;
            GUI.Box(new Rect(x, y, width, height), "", mouseDragSkin);
        }
        
    }
}