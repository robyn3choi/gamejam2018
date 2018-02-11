using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndGamePanel : MonoBehaviour, IPointerClickHandler {

    public GameObject credits;
    AudioSource c;
    AudioSource e;

    void Start() {
        c = GetComponents<AudioSource>()[0];
        e = GetComponents<AudioSource>()[1];
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        c.Play();
        e.Play();
        credits.SetActive(true);
        GameManager.instance.EndGame();
    }
}
