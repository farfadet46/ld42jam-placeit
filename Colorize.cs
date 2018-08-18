using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorize : MonoBehaviour {
    
    void Start ()
    {
        Color Ncolor = Random.ColorHSV();

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = Ncolor;
        }
    }
}
