
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphere : MonoBehaviour {

    [SerializeField]
    private Material baseMaterial;
    private Material currentMaterial;

    [SerializeField]
    private Gradient gradient;
    private Color[] colors;

    [SerializeField]
    private float colorMultiplier;

    private AudioPeer audioPeer;

    private MeshRenderer meshRenderer;

    private Vector2 noiseOffset = Vector2.zero;

    [SerializeField]
    private float noiseFrequency;

    private float lerpValue = 0.0f;
    private int audioBandNumber = 0;

    private void Start() {

        colors = new Color[29];
        for(int i = 0; i < 29; i++) {
            colors[i] = gradient.Evaluate(i * (1.0f / 29));
        }

        audioPeer = FindAnyObjectByType<AudioPeer>();

        meshRenderer = GetComponent<MeshRenderer>();

        currentMaterial = Instantiate(baseMaterial);
        currentMaterial.CopyPropertiesFromMaterial(baseMaterial);
        meshRenderer.material = currentMaterial;

        audioBandNumber = Mathf.FloorToInt((transform.position.x / 29) * audioPeer._audioBand.Length);

    }

    private void Update() {

        noiseOffset += new Vector2(
            audioPeer._audioBand[1] * Time.deltaTime,
            audioPeer._audioBand[4] * Time.deltaTime
        );

        float noise = Mathf.PerlinNoise((transform.position.x * noiseOffset.x) * noiseFrequency, (transform.position.z * noiseOffset.y) * noiseFrequency);
        noise = noise.Remap(0.0f, 1.0f, -0.35f, 0.35f);
        
        lerpValue = noise + audioPeer._audioBand[audioBandNumber].Remap(0.0f, 1.0f, 0.0f, 1.8f);
        transform.position = new Vector3(transform.position.x, lerpValue, transform.position.z);

        currentMaterial.SetFloat("_LerpAmount", lerpValue);

        Color mainColor;
        if(lerpValue > 0.0f) {
            mainColor = colors[(int)transform.position.x] * colorMultiplier * lerpValue;
        }
        else {
            mainColor = Color.black;
        }
        currentMaterial.SetColor("_Main_Color", mainColor);

    }

}