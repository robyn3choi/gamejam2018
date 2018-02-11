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
    public bool isGameEnd = false;
    float phase1Timer = 15;
    public GameObject GameOverStuff;
    public Button StartOverBtn;
    public Texture2D cursorTexture;
    AudioSource audio1; //riser and impact
    AudioSource audio2; // ringer
    AudioSource audio3; // happy chord
    float shepTime = 0.0f;
    float ringTime = 0.0f;
    public AudioClip ringerClip;
    public AudioClip impactClip;
    public bool canPlayerClick = true;

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
        audio1 = GetComponents< AudioSource > ()[0];
        audio2 = GetComponents< AudioSource > ()[1];
        audio3 = GetComponents< AudioSource > ()[2];

    }

    void Start()
    {
        StartCoroutine(Phase1Timer());
    }

    IEnumerator Phase1Timer() {
        while (phase1Timer >= 0 && !isGameOver) {
            phase1Timer -= Time.deltaTime;
            yield return null;
        }
        NextPhase();
        //PlayShepard();
        yield break;
    }

    public void GameOver()
    {
        isGameOver = true;
        print("WEDIDITREDDIT");
        audio1.Stop();
        audio2.Stop();
        StopAllCoroutines();
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
            canPlayerClick = true;
            Invoke("MoveToPhase4", 8);
        }
        if (phase == 2) {
            audio1.Play();
            Invoke("MakePlayerNotClick", 10);
        }
        if (phase == 6) {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene("phase6");
        }
    }

    void MakePlayerNotClick() {
        canPlayerClick = false;
    }

    void MoveToPhase4() {
        NextPhase();
        HelperManager.instance.Phase4();
        //StartCoroutine (FadeOut (audio2, 0.3f));
    }

    public void PlayImpact() {
        audio1.Stop();
        audio1.clip = impactClip;
        audio1.Play();
    }

    public void PlayRinger()
    {
        audio2.Play();
        StartCoroutine(phase2timerB());
    }

    IEnumerator phase2timerB()
    {
        while (audio2.volume > 0)
        {
            audio2.volume = (Mathf.Exp(-ringTime/3))-0.02f ;
            ringTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
    

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop ();
        audioSource.volume = startVolume;
    }

    public void EndGame()
    {
        isGameEnd = true;
        print("Thanks for playing!");
    }

    public void PlayChord() {
        audio3.Play();
        Invoke("NextPhase", 18);
    }
}
