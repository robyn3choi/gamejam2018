using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperManager : MonoBehaviour {

    public static HelperManager instance = null;
    List<GameObject> helpers = new List<GameObject>();
    float timer = 0;
    float timeInBetweenHelpers = 0.2f;

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
    }

	// Use this for initialization
	void Start () {
        foreach (Transform t in transform) {
            helpers.Add(t.gameObject);
        }
	}
	
    public void Phase4() {
        StartCoroutine(Phase4Coroutine());
    }

    IEnumerator Phase4Coroutine() {
        helpers[0].SetActive(true);

        yield return new WaitForSeconds(3);

        for (int i=1;i<helpers.Count;i++) {
            helpers[i].SetActive(true);
            yield return new WaitForSeconds(timeInBetweenHelpers);
        }

        yield return new WaitForSeconds(3);
        GameManager.instance.NextPhase();
        
        yield break;
    }
    
}
