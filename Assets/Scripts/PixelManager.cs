using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelManager : MonoBehaviour {

    List<Pixel> pixels = new List<Pixel>();
    public float timeBetweenPixelFades = 1; // will gradually decrease by GameManager
    float timer = 0;

	// Use this for initialization
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
                // TODO: replace with actual pixel's method
                randomPixel.Fade();
                timer = timeBetweenPixelFades;
            }
            else {
                timer += Time.deltaTime;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Pixel GetRandomPixel() {
        int randomIndex = Random.Range(0, pixels.Count);
        return pixels[randomIndex];
    }
}
