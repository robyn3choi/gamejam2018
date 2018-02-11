using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndGamePanel : MonoBehaviour, IPointerClickHandler {

    public GameObject credits;
    AudioSource c;
    AudioSource e;
    bool canEnd = false;

    void Start() {
        c = GetComponents<AudioSource>()[0];
        e = GetComponents<AudioSource>()[1];
        Invoke("canEndNow", 2);
    }

    void canEndNow() {
        canEnd = true;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (canEnd) {
            c.Play();
            e.Play();
            credits.SetActive(true);
            GameManager.instance.EndGame();
        }
    }
}
