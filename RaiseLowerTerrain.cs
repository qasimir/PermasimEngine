using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseLowerTerrain : MonoBehaviour {

    private Camera cam;
    private Terrain terrain;
    private TerrainTools terrainTools;

    void Start() {
        cam = Camera.main;
        terrain = Terrain.activeTerrain;
        terrainTools = GetComponent<TerrainTools>();
    }

    void Update() {

        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 100, false);
                AlterHeight(hit.point, 0.03f);
            }
        } else if (Input.GetMouseButton(1)) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 100, false);
                AlterHeight(hit.point, -0.03f);
            }
        }
    }

    private void AlterHeight(Vector3 point,float strength) {


        int heightMapWidth = terrain.terrainData.heightmapWidth;
        int heightMapHeight = terrain.terrainData.heightmapHeight;

        float terrainDataSizeX = terrain.terrainData.size.x;
        float terrainDataSizeZ = terrain.terrainData.size.z;

        int mouseX = (int)((point.x * heightMapWidth) / terrainDataSizeX);
        int mouseZ = (int)((point.z * heightMapHeight) / terrainDataSizeZ);

        int brushWidth = 20;

        int XMinimum = (mouseX - brushWidth) > 0 ? (mouseX - brushWidth) : 0;
        int XMaximum = (mouseX + brushWidth) < heightMapWidth ? (mouseX + brushWidth) : heightMapWidth;
        int ZMinimum = (mouseZ - brushWidth) > 0 ? (mouseZ - brushWidth) : 0;
        int ZMaximum = (mouseZ + brushWidth) < heightMapHeight ? (mouseZ + brushWidth) : heightMapHeight;

        float[,] heights = terrain.terrainData.GetHeights(XMinimum, ZMinimum, XMaximum - XMinimum, ZMaximum - ZMinimum);
       

        for (int x = 0; x < XMaximum - XMinimum; x++) {
            for (int z = 0; z < ZMaximum - ZMinimum; z++) {
                heights[z, x] += terrainTools.cosineWeighting((float)x, (float)z, (XMaximum - XMinimum)/2, (ZMaximum - ZMinimum) / 2, brushWidth, strength) * Time.deltaTime;
            }
        }
        

        terrain.terrainData.SetHeights(XMinimum, ZMinimum, heights);
    }
}