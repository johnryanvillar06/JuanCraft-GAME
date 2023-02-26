using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swiitch : MonoBehaviour
{
    public GameObject[] background;
    public GameObject hidehelppanel;
    int index;
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 10)
            index = 10;
        if (index < 0)
            index = 0;

        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
        }

    }
    public void Next()
    {
        index += 1;
        int number = background.Length;
        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

        if (index >= number-1)
        {
            hidehelppanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        } 
    }
    public void Previous()
    {
        index -= 1;
        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);

        }
        Debug.Log(index);
    }
}
