using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Conversationchat : MonoBehaviour
{
    public string[] messages;

    public string[] charactername;

    public int chatnum = 0;

    public bool swap = true;

    public Text chatcharacterText;
    public Text chatoldmanText;

    public GameObject maincharacter;
    public GameObject oldmancharacter;
    public GameObject ChatPanel;


    public void convertion()
    {
        if (chatnum < messages.Length)
        {
            if (charactername[chatnum] == "Juan")
            {
                chatcharacterText.text = messages[chatnum];
                maincharacter.SetActive(true);
                oldmancharacter.SetActive(false);
            }
            else if (charactername[chatnum] == "Oldman")
            {
                chatoldmanText.text = messages[chatnum];
                maincharacter.SetActive(false);
                oldmancharacter.SetActive(true);
            }
            chatnum++;
        }
        else
        {
            ChatPanel.SetActive(false);
        }
    }

    public void endStory()
    {
        if (chatnum < messages.Length)
        {
            if (charactername[chatnum] == "Juan")
            {
                chatcharacterText.text = messages[chatnum];
                maincharacter.SetActive(true);
                oldmancharacter.SetActive(false);
            }
            else if (charactername[chatnum] == "Oldman")
            {
                chatoldmanText.text = messages[chatnum];
                maincharacter.SetActive(false);
                oldmancharacter.SetActive(true);
            }
            chatnum++;
        }
        else
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
