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
        StartOverBtn.enabled = true;
        StartOverBtn.onClick.AddListener(StartOver);

    }

    public void StartOver()
    {
        print("Annyeonghaseyo");

        SceneManager.LoadScene("Main");
    }

    void NextPhase()
    {
        phase++;
        print("ON PHASE: " + phase);
    }

    void EndGame()
    {
        
    }

    void Update()
    {

    }
}
