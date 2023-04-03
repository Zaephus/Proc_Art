using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GenerationConfig genConfig;

    private SemiCircleGenerator semiCircleGenerator;
    private TowerGenerator towerGenerator;
    private WallGenerator wallGenerator;

    private bool isGenerating;

    private void Start() {
        semiCircleGenerator = GetComponent<SemiCircleGenerator>();
        towerGenerator = GetComponent<TowerGenerator>();
        wallGenerator = GetComponent<WallGenerator>();
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Space) && !isGenerating) {
            StartCoroutine(Generate());
        }

    }

    private IEnumerator Generate() {

        isGenerating = true;

        if(transform.childCount > 0) {
            for(int i = transform.childCount-1; i >= 0; i--) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        yield return new WaitForEndOfFrame();

        foreach(TowerConfig tc in genConfig.towerConfigs) {
            towerGenerator.StartCoroutine(towerGenerator.Generate(tc));
            if(tc.delayBetweenBricks > 0) {
                yield return new WaitForSeconds(tc.delayBetweenBricks);
            }
            else {
                yield return new WaitForEndOfFrame();
            }
        }

        yield return new WaitForEndOfFrame();

        foreach(SemiCircleConfig scc in genConfig.semiCircleConfigs) {
            semiCircleGenerator.StartCoroutine(semiCircleGenerator.Generate(scc));
            if(scc.delayBetweenBricks > 0) {
                yield return new WaitForSeconds(scc.delayBetweenBricks);
            }
            else {
                yield return new WaitForEndOfFrame();
            }
        }

        yield return new WaitForEndOfFrame();

        foreach(WallConfig wc in genConfig.wallConfigs) {
            wallGenerator.StartCoroutine(wallGenerator.Generate(wc));
            if(wc.delayBetweenBricks > 0) {
                yield return new WaitForSeconds(wc.delayBetweenBricks);
            }
            else {
                yield return new WaitForEndOfFrame();
            }
        }

        isGenerating = false;
        yield return new WaitForEndOfFrame();

    }

}