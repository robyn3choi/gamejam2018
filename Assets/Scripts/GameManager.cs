using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int phase = 1;
    public bool isGameOver = false;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        print("WEDIDITREDDIT");
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
