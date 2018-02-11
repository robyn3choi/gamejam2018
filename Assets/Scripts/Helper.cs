using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Helper : MonoBehaviour {

    float clickSpeed = 1.5f;
    float moveSpeed = 200;
    public Pixel myPixel;

	// Use this for initialization
	void Start () {
        Vector3 destination = myPixel.transform.position + new Vector3(60, -50, 0);
        transform.DOMove(destination, 2).OnComplete(StartClicking);
	}
        
    public void StartClicking() {
        InvokeRepeating("Click", 0.1f, clickSpeed);
    }

    void Click() {
        myPixel.UnFadeByHelper();
    }
}
