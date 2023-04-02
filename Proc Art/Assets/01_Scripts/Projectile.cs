using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Rigidbody body;

    private int counter;

    public void OnStart() {
        body = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(body.velocity == Vector3.zero) {
            counter++;
            if(counter > 5) {
                Destroy(gameObject);
            }
        }
        else {
            counter = 0;
        }

        if(transform.position.y < 0.0f) {
            Destroy(gameObject);
        }
    }

}