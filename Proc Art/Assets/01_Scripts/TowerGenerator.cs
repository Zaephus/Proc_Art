using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject brickPrefab;

    [SerializeField]
    private Vector2Int brickAmount;

    [SerializeField]
    private Vector2 brickMargin;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Generate();
        }
    }

    private void Generate() {

        if(transform.childCount > 0) {
            for(int i = transform.childCount-1; i >= 0; i--) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        Vector2 brickSize = brickPrefab.transform.localScale;

        float startOffset = -0.5f + (brickSize.x * brickAmount.x + (brickAmount.x - 1) * brickMargin.x) * 0.5f;

        float xOffset = 0.0f;
        int xAmount = brickAmount.x;

        for(int y = 0; y < brickAmount.y; y++) {

            if(y % 2 == 0) {
                xOffset = -startOffset;
                xAmount = brickAmount.x;
            }
            else {
                xOffset = 0.5f * brickSize.x - startOffset;
                xAmount = brickAmount.x - 1;
            }

            for(int x = 0; x < xAmount; x++) {
                Vector3 pos = transform.position + new Vector3(
                    (x * brickSize.x * (1 + brickMargin.x)) + xOffset,
                    brickSize.y * 0.5f + (y * brickSize.y * (1 + brickMargin.y)),
                    0
                );
                Instantiate(brickPrefab, pos, brickPrefab.transform.rotation, transform);
            }

        }

    }

}