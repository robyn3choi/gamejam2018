using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour {

    public Color a;
    public Color b;
    public Color c;
    public Color d;
    public Color e;
    public Color f;
    public Color g;
    public Color h;

    public static List<Color> colorList = new List<Color>();

    void Awake()
    {
        colorList.Add(a);
        colorList.Add(b);
        colorList.Add(c);
        colorList.Add(d);
        colorList.Add(e);
        colorList.Add(f);
        colorList.Add(g);
        colorList.Add(h);
    }

    public static Color GetRandomColor() {
        return colorList[Random.Range(0, colorList.Count)];
    }

}
