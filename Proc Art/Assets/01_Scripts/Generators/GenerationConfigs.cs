using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StructureConfig {

    public Vector2Int brickAmount;
    public Vector2 brickMargin;

    [Range(0, 2)]
    public float delayBetweenBricks;

    [Range(0, 1), Tooltip("Chance for the generation of a brick")]
    public float brickGenChance;
    [Range(0, 1)]
    public float explosiveBrickChance;

    public Vector2 positionOffset;

}

[System.Serializable]
public class TowerConfig : StructureConfig {}

[System.Serializable]
public class WallConfig : StructureConfig {}

[System.Serializable]
public class SemiCircleConfig : StructureConfig {
    [Range(-Mathf.PI, Mathf.PI)]
    public float rotationOffset;
}