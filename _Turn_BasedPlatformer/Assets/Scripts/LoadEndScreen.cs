using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEndScreen : MonoBehaviour{

    GameManager gM;

    private void Start() {
        gM = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        gM.LoadEndScreen();
    }
}
