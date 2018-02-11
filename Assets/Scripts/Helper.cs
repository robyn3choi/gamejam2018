using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Helper : MonoBehaviour {

    float clickSpeed = 1.8f;
    float moveSpeed = 200;
    public Pixel myPixel;

	// Use this for initialization
	void Start () {
        if (GameManager.instance.phase != 6) {
            Vector3 destination = myPixel.transform.position + new Vector3(60, -50, 0);
            transform.DOMove(destination, 2).OnComplete(StartClicking);
        }
        else {
            StartClicking();
        }
	}
        
    public void StartClicking() {
        InvokeRepeating("Click", 0.1f, clickSpeed);
    }

    void Click() {
        myPixel.UnFadeByHelper();
    }

    void Update() {
        if (GameManager.instance.isGameEnd) {
            CancelInvoke();
        }
    }
}
