using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int phase = 1;
    public bool isGameOver = false;
    float phase1Timer = 15;
    public GameObject GameOverStuff;
    public Button StartOverBtn;
    public AudioSource Shepard;
    float shepTime = 0.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        GameOverStuff.SetActive(false);
        StartOverBtn.enabled = false;
        Shepard = GetComponent< AudioSource > ();
    }

    void Start() {
        StartCoroutine(Phase1Timer());
    }

    IEnumerator Phase1Timer() {
        while (phase1Timer >= 0) {
            phase1Timer -= Time.deltaTime;
            yield return null;
        }
        NextPhase();
        yield break;
    }

    public void GameOver()
    {
        isGameOver = true;
        print("WEDIDITREDDIT");

        GameOverStuff.SetActive(true);
       // StartOverBtn.enabled = true;
        StartOverBtn.onClick.AddListener(StartOver);
    }

    public void StartOver()
    {
        print("Annyeonghaseyo");
        SceneManager.LoadScene("Main");
    }

    public void NextPhase()
    {
        phase++;
        print("ON PHASE: " + phase);
    }

    public void PlayShepard()
    {
        Shepard.volume = 0;
        Shepard.Play();
        phase2Audio();
    }

    void phase2Audio()
    {
        StartCoroutine(phase2timer());
    }

    IEnumerator phase2timer()
    {
        while (Shepard.volume < 0.95)
        {
            Shepard.volume = 1/(1+(Mathf.Exp(-(shepTime - 5)/3)));
            shepTime += Time.deltaTime;
            yield return null;
        }
        NextPhase();
        yield break;
    }

        void EndGame()
    {
        
    }
}
