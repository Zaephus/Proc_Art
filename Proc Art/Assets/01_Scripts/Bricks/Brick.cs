using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private void Update() {
        if(transform.position.y < 0.0f) {
            Destroy(gameObject);
        }
    }

}
