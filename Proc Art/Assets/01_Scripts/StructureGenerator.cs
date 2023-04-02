using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour {

    [SerializeField]
    protected GameObject brickPrefab;

    [SerializeField]
    protected Vector2Int brickAmount;
    [SerializeField]
    protected Vector2 brickMargin;

    [SerializeField, Range(0, 2)]
    protected float delayBetweenBricks;

    [SerializeField, Range(0, 1), Tooltip("Chance for the generation of a brick")]
    protected float brickChance;

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
}