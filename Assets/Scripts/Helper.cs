using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Helper : MonoBehaviour {

    float clickSpeed = 1;
    float moveSpeed = 200;
    public Pixel myPixel;

	// Use this for initialization
	void Start () {
        Vector3 destination = myPixel.transform.position + new Vector3(60, -50, 0);
        transform.DOMove(destination, 2).OnComplete(StartClicking);
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position = Vector2.MoveTowards(transform.position, myPixel.transform.position, moveSpeed * Time.deltaTime);
	}
        
    public void StartClicking() {
        InvokeRepeating("Click", 0.1f, clickSpeed);
    }

    void Click() {
        myPixel.UnFade();
    }
}
