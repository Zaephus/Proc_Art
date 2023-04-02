using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : WallGenerator {

    [SerializeField]
    private float radius;

    protected override IEnumerator Generate() {

        if(transform.childCount > 0) {
            for(int i = transform.childCount-1; i >= 0; i--) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        float startOffset = ((brickAmount.x * brickSize.x + (brickAmount.x - 1) * brickMargin.x) * 0.5f) - (0.5f * brickSize.x);

        float xOffset = 0.0f;
        int xAmount = brickAmount.x;

        float iterator = 0;

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

                if(iterator * Random.value * 2 > brickChance) {
                    yield return new WaitForSeconds(delayBetweenBricks);
                    iterator = 0;
                    continue;
                }

                Vector3 pos = transform.position + new Vector3(
                    x * brickSize.x + x * brickMargin.x + xOffset,
                    brickSize.y * 0.5f + y * brickSize.y + y * brickMargin.y,
                    0
                );
                Instantiate(brickPrefab, pos, brickPrefab.transform.rotation, transform);

                iterator += 0.1f;

                yield return new WaitForSeconds(delayBetweenBricks);

            }

        }

    }

    private int CalculateLayerBrickAmount() {
        
        float innerRadius = radius - brickSize.z/2;
        float circumference = 2 * innerRadius * Mathf.PI;

        int maxBricks = Mathf.FloorToInt(circumference / brickSize.x);

        if(maxBricks <= brickAmount.x) {
            return maxBricks;
        }
        else {
            return brickAmount.x;
        }

    }

}