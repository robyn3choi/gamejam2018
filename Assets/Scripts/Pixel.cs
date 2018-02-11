using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pixel : MonoBehaviour {

    private Color colorStart;
    private Color colorEnd = Color.black;
    //public float dur = 3.0F;       //fade time duration
    private float t;                //lerp ctrl vbl
    public Button btn;
    public bool isFading;
    public bool hasFaded = false;
    Image image;

    void Start() {
        t = 0.0F;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(UnFade);
        image = GetComponent<Image>();
        image.color = Colors.GetRandomColor();
        colorStart = image.color;
    }
    
    void Update() {
        if (isFading && !GameManager.instance.isGameOver)
        {
            if (t < 1)
            {
                t += Time.deltaTime / PixelManager.instance.fadeDur;
            }
            else
            {
                isFading = false;
                hasFaded = true;
                if (GameManager.instance.phase == 1) {
                    GameManager.instance.GameOver();
                }
            }
        }
        image.color = Color.Lerp(colorStart, colorEnd, t);
    }

    public void UnFade()
    {
        if (!hasFaded) {
            t = 0.0f;
            isFading = false; 
            image.color = Colors.GetRandomColor();
        }
    }

    public void UnFadeByHelper() {
        t = 0.0f;
        isFading = true;  
        image.color = Colors.GetRandomColor();
    }
}