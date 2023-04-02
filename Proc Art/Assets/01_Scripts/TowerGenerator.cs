using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : StructureGenerator {

    protected override IEnumerator Generate() {

        isGenerating = true;

        if(transform.childCount > 0) {
            for(int i = transform.childCount-1; i >= 0; i--) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        float radius = CalculateRadius();
        
        float xOffset = 0;

        float iterator = 0;

        for(int y = 0; y < brickAmount.y; y++) {

            if(y % 2 == 0) {
                xOffset = 0;
            }
            else {
                xOffset = 0.5f * brickSize.x;
            }

            for(int x = 0; x < brickAmount.x; x++) {

                if(Mathf.Clamp01(iterator * Random.value) > brickChance) {
                    if(delayBetweenBricks > 0.0f) {
                        yield return new WaitForSeconds(delayBetweenBricks);
                    }
                    iterator = 0;
                    continue;
                }

                float theta = (x * brickSize.x + xOffset) * ((2 * Mathf.PI) / brickAmount.x);

                Vector3 pos = transform.position + new Vector3(
                    radius * Mathf.Cos(theta),
                    brickSize.y * 0.5f + y * brickSize.y + y * brickMargin.y,
                    radius * Mathf.Sin(theta) 
                );

                Vector3 lookPos = new Vector3(transform.position.x, pos.y, transform.position.z);
                Quaternion rot = Quaternion.LookRotation(pos - lookPos, transform.up);

                Instantiate(brickPrefab, pos, rot, transform);

                iterator += 0.1f;

                if(delayBetweenBricks > 0.0f) {
                    yield return new WaitForSeconds(delayBetweenBricks);
                }

            }

        }

        isGenerating = false;
        yield return null;

    }

    private float CalculateRadius() {
        float innerRadius = (brickAmount.x * (brickSize.x + brickMargin.x)) / (2 * Mathf.PI);
        return innerRadius + brickSize.z/2;
    }

}