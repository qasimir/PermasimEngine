using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrainHeight : MonoBehaviour {

	public Terrain TerrainMain;


	void OnGUI() {
		if (GUI.Button(new Rect(30,30,200,30), "Change Terrain Height")) {
			//get the height and width
			int xRes = TerrainMain.terrainData.heightmapWidth;
			int yRes = TerrainMain.terrainData.heightmapHeight;
			Debug.Log (xRes + ", " + yRes);

			float[,] heights = TerrainMain.terrainData.GetHeights(0,0,xRes,yRes);

			//manipulate the heights data

			heights [10, 10] = 1f;

			TerrainMain.terrainData.SetHeights (0, 0, heights); //does not revert

		}


			
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
