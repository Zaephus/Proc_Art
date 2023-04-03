using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Generation Config")]
public class GenerationConfig : ScriptableObject {
    public TowerConfig[] towerConfigs;
    public SemiCircleConfig[] semiCircleConfigs;
    public WallConfig[] wallConfigs;
}