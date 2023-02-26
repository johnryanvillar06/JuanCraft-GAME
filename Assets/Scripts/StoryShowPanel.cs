using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryShowPanel : MonoBehaviour
{

    public GameObject[] story;

    public GameObject endingbutton;
    public GameObject Donebuttonending;
    public GameObject Nextbuttonending;
    void Start()
    {
        if (PreSetupManager.level == 1)
        {
            story[0].SetActive(true);
        }
        else if (PreSetupManager.level == 6)
        {
            story[1].SetActive(true);
        }
        else if (PreSetupManager.level == 11)
        {
            story[2].SetActive(true);
        }
        ending();
    }

    public void ending()
    {
        if (PreSetupManager.level == 15)
        {
            endingbutton.SetActive(true);   
            Donebuttonending.SetActive(false);
            Nextbuttonending.SetActive(false);
        }
    }
}
