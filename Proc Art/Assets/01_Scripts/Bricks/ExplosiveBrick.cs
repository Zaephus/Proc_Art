using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBrick : MonoBehaviour {

    [SerializeField]
    private Vector2 forceRange;

    [SerializeField]
    private Vector2 waitTimeRange;
    [SerializeField]
    private float timeBeforeDestroy;

    private Rigidbody body;

    private void Start() {
        body = GetComponent<Rigidbody>();
        StartCoroutine(Explode(Random.Range(waitTimeRange.x, waitTimeRange.y)));
    }

    private void Update() {
        if(transform.position.y < 0.0f) {
            Destroy(gameObject);
        }
    }

    private IEnumerator Explode(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        body.AddForce(Random.Range(forceRange.x, forceRange.y) * transform.up, ForceMode.Impulse);

        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }

}