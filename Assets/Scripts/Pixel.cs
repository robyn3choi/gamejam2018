using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pixel : MonoBehaviour {

    private Color colorStart = Color.cyan;
    private Color colorEnd = Color.grey;
    private float dur = 3.0F;       //fade time duration
    private float t;
    public Button pixel1;

    // Use this for initialization
    void Start() {
        t = 0.0F;      //lerp ctrl vbl
        Button btn = pixel1.GetComponent<Button>();
        btn.onClick.AddListener(UnFade);
    }

    // Update is called once per frame
    void Update() {
        ColorBlock cb = pixel1.colors;
        cb.normalColor = Color.Lerp(colorStart, colorEnd, t);
        cb.highlightedColor = Color.Lerp(colorStart, colorEnd, t);
        cb.pressedColor = Color.Lerp(colorStart, colorEnd, t);
        GetComponent<Button>().colors = cb;

        if (t < 1)
        {
            t += Time.deltaTime / dur;
        }
    }

    void UnFade()
    {
        t = 0.0f;
    }
}