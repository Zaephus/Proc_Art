using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : StructureGenerator {

    public IEnumerator Generate(TowerConfig _config) {

        float radius = CalculateRadius(_config.brickAmount.x, _config.brickMargin.x);
        
        float xOffset = 0;

        float iterator = 0;

        for(int y = 0; y < _config.brickAmount.y; y++) {

            if(y % 2 == 0) {
                xOffset = 0;
            }
            else {
                xOffset = 0.5f * brickSize.x;
            }

            for(int x = 0; x < _config.brickAmount.x; x++) {

                if(Mathf.Clamp01(iterator * Random.value) > _config.brickGenChance) {
                    if(_config.delayBetweenBricks > 0.0f) {
                        yield return new WaitForSeconds(_config.delayBetweenBricks);
                    }
                    iterator = 0;
                    continue;
                }

                float theta = (x * brickSize.x + xOffset) * ((2 * Mathf.PI) / _config.brickAmount.x);

                Vector3 pos = transform.position + new Vector3(
                    radius * Mathf.Cos(theta) + _config.positionOffset.x,
                    brickSize.y * 0.5f + y * brickSize.y + y * _config.brickMargin.y,
                    radius * Mathf.Sin(theta) + _config.positionOffset.y 
                );

                Vector3 lookPos = new Vector3(transform.position.x + _config.positionOffset.x, pos.y, transform.position.z + _config.positionOffset.y);
                Quaternion rot = Quaternion.LookRotation(pos - lookPos, transform.up);

                Instantiate(GetBrick(_config.explosiveBrickChance), pos, rot, transform);

                iterator += 0.1f;

                if(_config.delayBetweenBricks > 0.0f) {
                    yield return new WaitForSeconds(_config.delayBetweenBricks);
                }

            }

        }

        yield return null;

    }

    private float CalculateRadius(int _amountX, float _marginX) {
        float innerRadius = (_amountX * (brickSize.x + _marginX)) / (2 * Mathf.PI);
        return innerRadius + brickSize.z/2;
    }

}