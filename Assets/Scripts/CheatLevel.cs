using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatLevel : MonoBehaviour
{

    public void cheatcode()
    {
        PlayerPrefs.SetInt("level_status", 15);

        for(int i = 0; i < 15; i++)
        {
            PlayerPrefs.SetInt("level_star" + i, 3);
        }
        SceneManager.LoadScene("Menu");
    }
  
}
