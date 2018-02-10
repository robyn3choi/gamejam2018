using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int phase = 1;
    public bool isGameOver = false;
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
    }

    void EndGame()
    {
        
    }

    void Update()
    {

    }
}
