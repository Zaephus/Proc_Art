using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float shootStrength;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        GameObject proj = Instantiate(projectile, transform.position, projectile.transform.rotation, transform);
        proj.GetComponent<Rigidbody>().AddForce(shootStrength * transform.forward, ForceMode.Impulse);
    }

}