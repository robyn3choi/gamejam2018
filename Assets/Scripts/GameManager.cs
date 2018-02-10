using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int phase = 1;
    public bool isGameOver = false;
    float phase1Timer = 15;

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
