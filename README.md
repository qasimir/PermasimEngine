# PermasimEngine
Permaculture Simulator Engine

This is a soil and plant growth simulator which is to be used in conjunction with a unity app to create a permaculture game. 

## Technical Notes:

Most of the complexity of this simulation is in the soil dynamics. Soil is a difficult thing to model, and I have opted, in most cases to have simple, often linear approximations to soil dynamics.
The soil is represented in the following heirarchy:

__WorldMap__
    |
    |
    |
    v
__Segment__
    |----------------------|
    |                      |
    |                      |
    v                      v
__SoilProfile__        __Plant__
    |
    |
    |
    v
__SoilHorizon__
 
 
__WorldMap__: this is the interface between the backend and the front end. Most importantly, it contains an array of segments
__Segment__: this is the lowest resolution object on the world map. A segment contains plant species on it, has a soil profile, and contains pest species on it as well
__SoilProfile__: a soil profile consists of several layers of horizons. Each horizon has distinct soil characteristics and compositions. 
__SoilHorizon__: a layer of soil which has chaacteristics distinct from those around it. There are usually three horizons to the profile (topsoil, substrate and bedrock)
__Plant__: If you have difficulty understanding what a plant is, go outside and find something green. It is probably what you are looking for.



There are several ways in which the state of the game changes:

1) through user input.
2) when the user chooses to evolve time.

### 1) through user input

The user can alter the terrain by altering certain aspects as they play. For instance, they may decide to dig a section of the terrain. The immediate effects of this are calculated when they perform the action. 
The code for this is usually in the class which they are affecting. For example, if they are pruning a plant, then the method ```prunePlant()``` in the class ```Plant``` will be run.

### 2) when the user chooses to evolve time.
 
When the user chooses to advance in a time period, (i.e.: wait a week/end the day) certain processes will occur in the simulation. It will rain, the wind will blow, the temperature will rise or fall, seasons will pass etc.
The effects of time passing are handled in the ```TimeEvolver``` class. Various sub routines are handled by the ```*Processor``` classes, (for example: ```PlantProcessor```)