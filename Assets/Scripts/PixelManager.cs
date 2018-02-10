using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelManager : MonoBehaviour {

    public static PixelManager instance = null;
   
    List<Pixel> pixels = new List<Pixel>();
    public float timeBetweenPixelFades = 1; // will gradually decrease by GameManager
    public float fadeSpeed = 3;
    float timer = 0;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null) {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this) {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        }
    }
        
	void Start () {
        // get all the Pixel components in my children and add to my pixel list
        foreach (Transform t in transform) {
            Pixel pixel = t.GetComponent<Pixel>();
            pixels.Add(pixel);
        }

        StartCoroutine(FadeRandomPixels());
	}

    IEnumerator FadeRandomPixels() {
        while (true) {
            if (timer >= timeBetweenPixelFades) {
                Pixel randomPixel = GetRandomPixel();
                if (!randomPixel.isFading) {
                    randomPixel.isFading = true;
                }
                timer = 0;
            }
            else {
                timer += Time.deltaTime;
            }
            yield return null;
        }
    }

    Pixel GetRandomPixel() {
        int randomIndex = Random.Range(0, pixels.Count);
        return pixels[randomIndex];
    }
}
