using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WorldMap {

    public static WorldMap instance;
    public static readonly int mapWidth = 256;
    public static readonly int mapHeight = 256;
    public Segment[,] segments;

    static WorldMap() {
        instance = new WorldMap();
    }

    private WorldMap() {
        this.segments = new Segment[mapWidth, mapHeight];
        // construct segments from unity terrain info
    }
}

