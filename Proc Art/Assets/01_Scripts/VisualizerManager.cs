
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerManager : MonoBehaviour {

    [SerializeField]
    private GameObject visualizer;
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private AudioPeer audioPeer;

    private bool isVisualizing = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && isVisualizing) {
            OpenMenu();
        }
    }

    public void StartVisualizing(AudioClip _clip) {
        menu.SetActive(false);

        audioPeer._audioClip = _clip;
        visualizer.SetActive(true);
        isVisualizing = true;
        audioPeer.Start();
    }

    public void Exit() {
        Application.Quit();
    }

    private void OpenMenu() {
        visualizer.SetActive(false);
        isVisualizing = false;
        menu.SetActive(true);
    }

}