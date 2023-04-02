using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour {

    [SerializeField]
    protected GameObject brickPrefab;
    [SerializeField]
    private GameObject explosiveBrickPrefab;

    [SerializeField]
    protected Vector2Int brickAmount;
    [SerializeField]
    protected Vector2 brickMargin;

    [SerializeField, Range(0, 2)]
    protected float delayBetweenBricks;

    [SerializeField, Range(0, 1), Tooltip("Chance for the generation of a brick")]
    protected float brickGenChance;
    [SerializeField, Range(0, 1)]
    private float explosiveBrickChance;

    [SerializeField]
    protected Vector2 positionOffset;

    protected Vector3 brickSize;

    protected bool isGenerating;

    private void Start() {
        brickSize = brickPrefab.transform.localScale;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && ! isGenerating) {
            StartCoroutine(Generate());
        }
    }

    protected virtual IEnumerator Generate() {
        yield return null;
    }

    protected GameObject GetBrick() {
        if(Random.value < explosiveBrickChance) {
            return explosiveBrickPrefab;
        }
        else {
            return brickPrefab;
        }
    }

}