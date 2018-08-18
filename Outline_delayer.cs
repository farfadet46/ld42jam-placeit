using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_delayer : MonoBehaviour {

    public float delayer = 10f;
    float delay;
    public bool Activated = false;

    void Update () {
        if (Activated)
        {
            if (delay > 0)
            {
                delay--;
            }
            else
            {
                Activated = false;
                this.GetComponent<Outline>().enabled = false;
            }
        }
	}
    public void Activate()
    {
        this.GetComponent<Outline>().enabled = true;
        Activated = true;
        delay = delayer;
    }
}
