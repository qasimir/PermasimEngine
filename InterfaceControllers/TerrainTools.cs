using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TerrainTools : MonoBehaviour {
    public static Terrain terrain;

    public float cosineWeighting(float xPoint, float yPoint, float xCentre, float yCentre,
        int width = 20, float strength = 0.03f) {
        return cosineWeighting(new Vector2 (xPoint,yPoint), new Vector2 (xCentre,yCentre),
            width,strength);
    }

    public float cosineWeighting(Vector2 point, Vector2 centre,
        int width = 20, float strength = 0.03f) {
        //going by the formula: (S*cos(|x|*pi/W) + 1) / 2

        float dist = Vector2.Distance(centre, point);
        if (dist >= width) {
            // stops the wave short, and catches case where width = 0
            return 0f; 
        }
        float pi = Mathf.PI;
        float operand = (dist * pi) / (width);
        float value = strength * (( Mathf.Cos(operand) + 1) / 2);

        return value;
    }

    public static void raycastedVectorToTerrainCoord(Vector3 point, string propertyType, out int mouseX, out int mouseZ) {
        TerrainData terrainData = terrain.terrainData;
        PropertyInfo propertyWidth = terrainData.GetType().GetProperty(propertyType + "Width");
        PropertyInfo propertyHeight = terrainData.GetType().GetProperty(propertyType + "Height");

        int width = (int)propertyWidth.GetValue(terrain.terrainData, null);
        int height = (int)propertyHeight.GetValue(terrain.terrainData, null);
        
        float terrainDataSizeX = terrainData.size.x;
        float terrainDataSizeZ = terrainData.size.z;

        mouseX = (int)((point.x * width) / terrainDataSizeX);
        mouseZ = (int)((point.z * height) / terrainDataSizeZ);
    }


}
