using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndGamePanel : MonoBehaviour, IPointerClickHandler {

    public GameObject credits;
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        audio.Play();
        credits.SetActive(true);
        GameManager.instance.EndGame();
    }
}
