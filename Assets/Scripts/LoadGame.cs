using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject load;
    public GameObject loaddialog;
    public GameObject MenuPanel;
    public GameObject Startagaindialog;


    public void loadgame()
    {
        if (PlayerPrefs.GetInt("level_status") == 0)
        {
            loaddialog.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("level_status") > 1)
        {
            load.SetActive(true);
            MenuPanel.SetActive(false);
        }

       
    }
    public void startgame()
    {
        if (PlayerPrefs.GetInt("level_status") == 0)
        {
            load.SetActive(true);
            MenuPanel.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("level_status") > 1)
        {
            Startagaindialog.SetActive(true);
        }
    }

    public void resetall()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }

    
}
