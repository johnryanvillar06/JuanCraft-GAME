using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void nextscene() {
        SceneManager.LoadScene("Stage");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }


    public void quit() {
        Application.Quit();
    }
    public void resetall()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }


    public static void showWindow(CanvasGroup canvas)
    {
        showWindow(canvas, true);
    }

    public static void hideWindow(CanvasGroup canvas)
    {
        showWindow(canvas, false);
    }

    private static void showWindow(CanvasGroup canvas, bool show)
    {
        canvas.alpha = show ? 1 : 0;
        canvas.interactable = show;
        canvas.blocksRaycasts = show;
    }

}
