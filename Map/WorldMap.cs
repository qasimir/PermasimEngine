using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WorldMap {

    public static WorldMap instance = new WorldMap();
    public static readonly int mapWidth = 256;
    public static readonly int mapHeight = 256;
    public Segment[,] segments;

    private WorldMap() {
        this.segments = new Segment[mapWidth, mapHeight];
        // construct segments from unity terrain info
    }
}

