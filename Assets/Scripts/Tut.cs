using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tut : MonoBehaviour
{
    Animator animtut;
    public Button[] barray;


    private void Start()
    {
        animtut = GetComponent<Animator>();

        foreach(Button b in barray)
        {
            b.interactable = false;
        }
        Time.timeScale = 0f;
    }
    public void Endtut ()
    {
        foreach (Button b in barray)
        {
            b.interactable = true;
        }
        Time.timeScale = 1f;

    }
    void ChangeAnimation ()
    {
        animtut.SetInteger("Change", animtut.GetInteger("Change") + 1);
    }
    private void Update ()
    {
        if (Input.anyKeyDown)
        {
            ChangeAnimation();
        }
    }
}
