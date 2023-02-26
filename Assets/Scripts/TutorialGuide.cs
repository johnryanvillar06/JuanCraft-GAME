using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialGuide : MonoBehaviour
{
    public GameObject ChatGuidePanel;
    public string [] chatguide;
    
    public Text chattext;
    int chatnumber = 0;

    public int countclickcontroller;
    public int countclickcontrollerlimit;

    public GameObject Controllerbuttons;
    public GameObject ControllerHelpGuide;

    //PickupGuide
    int countpickup=0;
    public GameObject Pickupbutton;
    public GameObject PickupGuide;


    public GameObject ViewButton;
    public GameObject ViewHelpGuide;
    public GameObject ViewItemGuide;
    public GameObject DropHereGuide;
    public GameObject DropStoreHelpGuide;


    //Text CashGuide
    public GameObject CashGuide;
    public GameObject CashButton;
    public GameObject textcassh1CashGuide;
    public GameObject textcassh2CashGuide;
    int countcashguide = 0;

    public GameObject TimerText;
    public GameObject TimerHelpGuide;

    public GameObject pausebutton;
    public GameObject pausepanel;

    public GameObject helpbutton;
    public GameObject helppanel;

    public GameObject clipbutton;
    public GameObject clippanel;


    public GameObject truckpanel;
    int panelcounttruck = 0;

    public GameObject Trashpanel;
    public GameObject leststart;

    public void conversition() {

        chatnumber++;
        if (chatnumber == chatguide.Length)
        {
            ChatGuidePanel.gameObject.SetActive(false);
            ControllerHelpGuide.SetActive(true);
            Controllerbuttons.SetActive(true);

        }
        else if (chatnumber <= chatguide.Length)
        {
            chattext.text = chatguide[chatnumber];
        }

    }


    public void Helpcontroller()
    {
        countclickcontroller++;
        if(countclickcontroller == countclickcontrollerlimit)
        {
            ControllerHelpGuide.SetActive(false);
            Pickupbutton.SetActive(true);
            PickupGuide.SetActive(true);
        }
    }

    public void pickupitem()
    {
        if (countpickup == 0)
        {
            ViewButton.SetActive(true);
            ViewHelpGuide.SetActive(true);
            PickupGuide.SetActive(false);
            countpickup++;
        }
    }
    public void drophereokay()
    {
        DropHereGuide.SetActive(false);
        DropStoreHelpGuide.SetActive(true);
    }

    public void dropstoreokay()
    {
        DropStoreHelpGuide.SetActive(false);
        CashGuide.SetActive(true);
        CashButton.SetActive(true);
    }

    public void viewitem()
    {
        ViewItemGuide.SetActive(false);
        ViewHelpGuide.SetActive(false);
        DropHereGuide.SetActive(true);

    }

    public void cashpanelguide()
    {
        if (countcashguide == 0)
        {
            textcassh1CashGuide.SetActive(true);
            countcashguide++;
        }
        else if (countcashguide ==1)
        {
            textcassh2CashGuide.SetActive(true);
            textcassh1CashGuide.SetActive(false);
            countcashguide++;
        }
        else if (countcashguide == 2)
        {
            TimerHelpGuide.SetActive(true);
            CashGuide.SetActive(false);
            TimerText.SetActive(true);
        }
    }
    public void timerpanelguide()
    {
        TimerHelpGuide.SetActive(false);
        pausebutton.SetActive(true);
        pausepanel.SetActive(true);
    }
    public void pausepanelguide()
    {
        helpbutton.SetActive(true);
        helppanel.SetActive(true);
        pausepanel.SetActive(false);

    }
    public void helppanelguide()
    {
        clipbutton.SetActive(true);
        clippanel.SetActive(true);
        helppanel.SetActive(false);
    }
    public void assignmentguide()
    {
        clippanel.SetActive(false);
    }

    public void assignmentpanel()
    {
        if (panelcounttruck == 0)
        {
            truckpanel.SetActive(true);
            panelcounttruck++;      
        }
    }

    public void trashpanelguide()
    {
        Trashpanel.SetActive(true);
    }

    public void truckpanelguide()
    {
        truckpanel.SetActive(true);
        Trashpanel.SetActive(false);
    }
    public void lestpanelguide()
    {
        truckpanel.SetActive(false);
        leststart.SetActive(true);
    }

    public void nextscene()
    {
        SceneManager.LoadScene("Stage");    
    }
}

