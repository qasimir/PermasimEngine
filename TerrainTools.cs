using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTools : MonoBehaviour {
    public int width = 5;
    public float bound = 1;
    public bool increaseElement = true;

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

}
