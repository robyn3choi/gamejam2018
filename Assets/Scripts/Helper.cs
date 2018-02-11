using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Helper : MonoBehaviour, IPointerEnterHandler {

    float clickSpeed = 1.5f;
    float moveSpeed = 200;
    public Pixel myPixel;
 

    // Use this for initialization
    void Start() {
        Vector3 destination = myPixel.transform.position + new Vector3(60, -50, 0);
        transform.DOMove(destination, 2).OnComplete(StartClicking);
        
    }

    public void StartClicking() {
        InvokeRepeating("Click", 0.1f, clickSpeed);
    }

    void Click() {
        myPixel.UnFadeByHelper();
    }

    private void Update()
    {
        if (GameManager.instance.phase == 5)
        {
            CancelInvoke();
            Vector3 mouseDest = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            transform.DOMove(mouseDest, 0.5f);
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameManager.instance.phase == 5)
        {
            //If your mouse hovers over the GameObject with the script attached, output this message
            Debug.Log("Mouse is over GameObject.");
            gameObject.SetActive(false);
        }
    }
}
