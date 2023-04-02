using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : StructureGenerator {

    protected override IEnumerator Generate() {

        isGenerating = true;

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

                if(iterator * Random.value * 2 > brickGenChance) {
                    if(delayBetweenBricks > 0.0f) {
                        yield return new WaitForSeconds(delayBetweenBricks);
                    }
                    iterator = 0;
                    continue;
                }

                Vector3 pos = transform.position + new Vector3(
                    x * brickSize.x + x * brickMargin.x + xOffset + positionOffset.x,
                    brickSize.y * 0.5f + y * brickSize.y + y * brickMargin.y,
                    positionOffset.y
                );

                Instantiate(GetBrick(), pos, GetBrick().transform.rotation, transform);

                iterator += 0.1f;

                if(delayBetweenBricks > 0.0f) {
                    yield return new WaitForSeconds(delayBetweenBricks);
                }

            }

        }

        isGenerating = false;
        yield return null;

    }

}