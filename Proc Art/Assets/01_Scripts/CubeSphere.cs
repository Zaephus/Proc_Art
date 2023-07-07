
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphere : MonoBehaviour {

    [SerializeField]
    private Material baseMaterial;
    private Material currentMaterial;

    private AudioPeer audioPeer;

    private MeshRenderer meshRenderer;

    private float lerpValue = 0.0f;
    private int audioBandNumber = 0;

    private void Start() {

        audioPeer = FindAnyObjectByType<AudioPeer>();

        meshRenderer = GetComponent<MeshRenderer>();

        currentMaterial = Instantiate(baseMaterial);
        currentMaterial.CopyPropertiesFromMaterial(baseMaterial);
        meshRenderer.material = currentMaterial;

        audioBandNumber = Mathf.FloorToInt((transform.position.x / 29) * audioPeer._audioBand.Length);

    }

    private void Update() {

        lerpValue = audioPeer._audioBand[audioBandNumber].Remap(0.0f, 1.0f, 0.0f, 1.8f);
        transform.position = new Vector3(transform.position.x, lerpValue, transform.position.z);

        currentMaterial.SetFloat("_LerpAmount", lerpValue);

    }

}