using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiCircleGenerator : StructureGenerator {

    [SerializeField, Range(0, Mathf.PI)]
    private float rotationOffset;

    protected override IEnumerator Generate() {

        isGenerating = true;

        if(transform.childCount > 0) {
            for(int i = transform.childCount-1; i >= 0; i--) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        float radius = CalculateRadius();
        
        float xOffset = 0.25f * brickSize.x;

        float iterator = 0;

        for(int y = 0; y < brickAmount.y; y++) {

            if(y % 2 == 0) {
                xOffset = 0.25f * brickSize.x;
            }
            else {
                xOffset = 0.75f * brickSize.x;
            }

            for(int x = 0; x < brickAmount.x; x++) {

                if(Mathf.Clamp01(iterator * Random.value) > brickGenChance) {
                    if(delayBetweenBricks > 0.0f) {
                        yield return new WaitForSeconds(delayBetweenBricks);
                    }
                    iterator = 0;
                    continue;
                }

                float theta = rotationOffset + (x * brickSize.x + xOffset) * (Mathf.PI / brickAmount.x);

                Vector3 pos = transform.position + new Vector3(
                    radius * Mathf.Cos(theta) + positionOffset.x,
                    brickSize.y * 0.5f + y * brickSize.y + y * brickMargin.y,
                    radius * Mathf.Sin(theta) + positionOffset.y
                );

                Vector3 lookPos = new Vector3(transform.position.x + positionOffset.x, pos.y, transform.position.z + positionOffset.y);
                Quaternion rot = Quaternion.LookRotation(pos - lookPos, transform.up);

                Instantiate(GetBrick(), pos, rot, transform);

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
        float innerRadius = (brickAmount.x * 2 * (brickSize.x + brickMargin.x)) / (2 * Mathf.PI);
        return innerRadius + brickSize.z/2;
    }
}