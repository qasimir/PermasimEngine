using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTools : MonoBehaviour {

	public Texture2D[] TerrainTextures;
	private static TerrainData terraindata;
	public Terrain terrain;

    private TerrainTools terrainTools;
    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        terrain = GetComponent<Terrain>();
        terraindata = terrain.terrainData;
        TerrainTextures = terraindata.alphamapTextures;
        terrainTools = GetComponent<TerrainTools>();
    }
		
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("p")) {
            paintUnderMouse();
        }
        if (Input.GetKey("o")) {
            //TerrainTools genericTools = GetComponent<TerrainTools>();
            //TerrainTools genericTools = GetComponent("TerrainTools") as TerrainTools;
            Texture2D[] textures = terraindata.alphamapTextures;
            foreach (Texture2D t in textures) {
                Debug.Log(t.name);
            }
        }

    }

    public static void paintLine(int startX, int startZ, int endX, int endZ, 
        int colour = 0, float strength = 1) {

        int xDist = endX - startX; // 10
        int zDist = endZ - startZ; //-10
        float xDistAbs = Mathf.Abs(xDist);
        float zDistAbs = Mathf.Abs(zDist);

        float grad = zDist / xDist; // -1
        float gradAbs = Mathf.Abs(grad);

        int z = 0;
        int x = 0;
        int zCounter = 0;

        while (x <= xDistAbs && z <= zDistAbs) {
            x += (int)(xDist / xDistAbs);
            while (zCounter <= gradAbs) {
                z += (int)(zDist / zDistAbs);
                paintCoord(x+startX, z+startZ, colour);
                zCounter++;
            }
            zCounter = 0;
        }

    }

    public static void paintRaycastedPoint(Vector3 point, int colour = 0, float strength = 1) {
        int mouseX;
        int mouseZ;
        TerrainTools.raycastedVectorToTerrainCoord(point, "alphamap", out mouseX, out mouseZ);
        paintCoord(mouseX, mouseZ, colour, strength);
    }

    public static void paintCoord(int x, int z, int colour = 0, float strength = 1) {
        int layers = terraindata.alphamapLayers;
        float[,,] map = new float[1, 1, layers];
        for (int i = 0; i < layers; i++) {
            if (i == colour) {
                map[0, 0, i] = strength;
            } else {
                map[0, 0, i] = (1 - strength) / layers;
            }
        }

        terraindata.SetAlphamaps(x, z, map);
    }
     /*
    public void paintSlopes (){
		float[,,] map = new float[terraindata.alphamapWidth, terraindata.alphamapHeight, 2];

		// For each point on the alphamap...
		for (int y = 0; y < terraindata.alphamapHeight; y++)
		{
			for (int x = 0; x < terraindata.alphamapWidth; x++)
			{
				// Get the normalized terrain coordinate that
				// corresponds to the the point.
				float normX = x * 1.0f / (terraindata.alphamapWidth - 1);
				float normY = y * 1.0f / (terraindata.alphamapHeight - 1);

				// Get the steepness value at the normalized coordinate.
				var angle = terraindata.GetSteepness(normX, normY);

				// Steepness is given as an angle, 0..90 degrees. Divide
				// by 90 to get an alpha blending value in the range 0..1.
				var frac = angle / 90.0;
				map[x, y, 1] = (float)frac;
				map[x, y, 0] = (float)(1 - frac);
			}
		}
		terraindata.SetAlphamaps(0, 0, map);
	}
    */
    private void paintUnderMouse() {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 100, false);
            AlterAlphaMap(hit.point);
        }
    }

    private void AlterAlphaMap(Vector3 point) {
        int brushWidth = 1;

        int alphaMapWidth = terrain.terrainData.alphamapWidth;
        int alphaMapHeight = terrain.terrainData.alphamapHeight;

        float terrainDataSizeX = terrain.terrainData.size.x;
        float terrainDataSizeZ = terrain.terrainData.size.z;

        int mouseX = (int)((point.x * alphaMapWidth) / terrainDataSizeX);
        int mouseZ = (int)((point.z * alphaMapHeight) / terrainDataSizeZ);

        int XMinimum = (mouseX - brushWidth) > 0 ? (mouseX - brushWidth) : 0;
        int XMaximum = (mouseX + brushWidth) < alphaMapWidth ? (mouseX + brushWidth) : alphaMapWidth;
        int ZMinimum = (mouseZ - brushWidth) > 0 ? (mouseZ - brushWidth) : 0;
        int ZMaximum = (mouseZ + brushWidth) < alphaMapHeight ? (mouseZ + brushWidth) : alphaMapHeight;


        float[,,] map = new float[XMaximum - XMinimum, ZMaximum - ZMinimum, terraindata.alphamapLayers];

        for (int x = 0; x < XMaximum - XMinimum; x++) {
            for (int z = 0; z < ZMaximum - ZMinimum; z++) {
                //float cosineWeighting = terrainTools.cosineWeighting((float)x, (float)z, (XMaximum - XMinimum) / 2, (ZMaximum - ZMinimum) / 2, brushWidth, 1.0f );
                map[x, z, 0] = 0;
                map[x, z, 1] = 1;
            }
        }

        terraindata.SetAlphamaps(XMinimum, ZMinimum, map);

    }



}
