using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Rigidbody body;

    private void Start() {
        body = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(transform.position.y < 0.0f) {
            Destroy(gameObject);
        }
    }

}