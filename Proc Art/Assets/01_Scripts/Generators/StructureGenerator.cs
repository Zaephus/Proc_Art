using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject brickPrefab;
    [SerializeField]
    private GameObject explosiveBrickPrefab;

    protected Vector3 brickSize;

    private void Start() {
        brickSize = brickPrefab.transform.localScale;
    }

    protected GameObject GetBrick(float _explosiveBrickChance) {
        if(Random.value < _explosiveBrickChance) {
            return explosiveBrickPrefab;
        }
        else {
            return brickPrefab;
        }
    }

}