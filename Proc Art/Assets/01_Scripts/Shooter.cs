using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float shootStrength;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            Shoot();
        }
    }

    private void Shoot() {
        Projectile proj = Instantiate(projectile, transform.position, projectile.transform.rotation, transform).GetComponent<Projectile>();
        proj.GetComponent<Rigidbody>().AddForce(shootStrength * transform.forward, ForceMode.Impulse);
        proj.OnStart();
    }

}