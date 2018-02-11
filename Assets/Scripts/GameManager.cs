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
    float phase1Timer = 10;
    public GameObject GameOverStuff;
    public Button StartOverBtn;
    public Texture2D cursorTexture;
    public AudioSource audio;
    float shepTime = 0.0f;
    float ringTime = 0.0f;
    public AudioClip ringerClip;

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

        Cursor.SetCursor(cursorTexture, Vector2.zero,CursorMode.Auto);
        audio = GetComponent< AudioSource > ();
    }

    void Start() {
        StartCoroutine(Phase1Timer());
    }

    IEnumerator Phase1Timer() {
        while (phase1Timer >= 0 && !isGameOver) {
            phase1Timer -= Time.deltaTime;
            yield return null;
        }
        NextPhase();
        PlayShepard();
        yield break;
    }

    public void GameOver()
    {
        isGameOver = true;
        print("WEDIDITREDDIT");

        GameOverStuff.SetActive(true);
        StartOverBtn.enabled = true;
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
        if (phase == 3) {
            Invoke("MoveToPhase4", 5);
        }
    }

    void MoveToPhase4() {
        NextPhase();
        HelperManager.instance.Phase4();
        audio.Stop();
    }

    public void PlayShepard()
    {
        audio.volume = 0;
        audio.Play();
        StartCoroutine(phase2timerA());
    }
    
    IEnumerator phase2timerA()
    {
        while (audio.volume < 0.99)
        {
            audio.volume = 1/(1+(Mathf.Exp(-2*(shepTime - 1.5f))));
            shepTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    public void PlayRinger()
    {
        audio.Stop();
        audio.clip = ringerClip;
        audio.Play();
        StartCoroutine(phase2timerB());
    }

    IEnumerator phase2timerB()
    {
        while (audio.volume > 0)
        {
            audio.volume = (Mathf.Exp(-ringTime/3))-0.02f ;
            ringTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }


    void EndGame()
    {
        
    }
}
