using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : StructureGenerator {

    public IEnumerator Generate(WallConfig _config) {

        float startOffset = ((_config.brickAmount.x * brickSize.x + (_config.brickAmount.x - 1) * _config.brickMargin.x) * 0.5f) - (0.5f * brickSize.x);

        float xOffset = 0.0f;
        int xAmount = _config.brickAmount.x;

        float iterator = 0;

        for(int y = 0; y < _config.brickAmount.y; y++) {

            if(y % 2 == 0) {
                xOffset = -startOffset;
                xAmount = _config.brickAmount.x;
            }
            else {
                xOffset = 0.5f * brickSize.x - startOffset;
                xAmount = _config.brickAmount.x - 1;
            }

            for(int x = 0; x < xAmount; x++) {

                if(iterator * Random.value * 2 > _config.brickGenChance) {
                    if(_config.delayBetweenBricks > 0.0f) {
                        yield return new WaitForSeconds(_config.delayBetweenBricks);
                    }
                    iterator = 0;
                    continue;
                }

                Vector3 pos = transform.position + new Vector3(
                    x * brickSize.x + x * _config.brickMargin.x + xOffset + _config.positionOffset.x,
                    brickSize.y * 0.5f + y * brickSize.y + y * _config.brickMargin.y,
                    _config.positionOffset.y
                );

                Instantiate(GetBrick(_config.explosiveBrickChance), pos, GetBrick(_config.explosiveBrickChance).transform.rotation, transform);

                iterator += 0.1f;

                if(_config.delayBetweenBricks > 0.0f) {
                    yield return new WaitForSeconds(_config.delayBetweenBricks);
                }

            }

        }

        yield return null;

    }

}