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
    public AudioSource Shepard;
    float shepTime = 0.0f;
    public AudioClip[] Ringer;

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
            Invoke("MoveToPhase4", 3);
        }
    }

    void MoveToPhase4() {
        NextPhase();
        HelperManager.instance.Phase4();
    }

    public void PlayShepard()
    {
        Shepard.volume = 0;
        Shepard.Play();
        StartCoroutine(phase2timer());
    }
    
    IEnumerator phase2timer()
    {
        while (Shepard.volume < 0.99)
        {
            Shepard.volume = 1/(1+(Mathf.Exp(-(shepTime - 3))));
            shepTime += Time.deltaTime;
            yield return null;
        }
        Shepard.volume = 0;
        yield break;
    }

        void EndGame()
    {
        
    }
}
