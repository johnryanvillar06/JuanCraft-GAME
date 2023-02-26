using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorationdesign : MonoBehaviour
{

    public GameObject cat;
    public GameObject dog;

    public GameObject catpanel;
    public GameObject dogpanel;

    public bool Catdisplay;
    public bool Dogdisplay;

    public void catpush()
    {
        if (Catdisplay)
        {
            catpanel.SetActive(true);
        }
    }

    public void dogpush()
    {
        if (Dogdisplay)
        {
            dogpanel.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == cat)
        {
            Catdisplay = true;
        }
        if (col.gameObject == dog)
        {
            Dogdisplay = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == cat)
        {
            Catdisplay = false;
        }
        if (col.gameObject == dog)
        {
            Dogdisplay = false;
        }

    }
}
