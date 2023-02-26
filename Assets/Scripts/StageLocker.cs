using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System;

public class StageLocker : MonoBehaviour
{
    public StageConfig config;

    [Header("UI")]
    public GameObject element;
    public Text message;

    public static List<StageConfig> list = new List<StageConfig>();

    
    [System.Serializable]
    public struct StageConfig
    {
        public int from;
        public int to;
        public int minStarToEnter;
    }


    void Start()
    {
        if(isStageNotAccessible())
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 190);
            Destroy(GetComponent<Button>());
            StartCoroutine(addComponentCoroutine());
        }

        if(list.Find((l) => l.from == config.from && l.to == config.to).minStarToEnter == 0)
        {
            list.Add(config);
        }
        
    }

    public static bool isStageAccessible(int level)
    {
        StageConfig config = list.Find((l) => l.from <= level && l.to >= level);

        int nextLevel = level + 1;
        if (config.minStarToEnter != 0 && nextLevel > config.to)
        {
            return !isStageNotAccessible(config);
        }else
        {
            return true;
        }
    }

    public static bool isStageNotAccessible(StageConfig config)
    {
        return config.minStarToEnter >= getStageScore(config.from, config.to);
    } 

    IEnumerator addComponentCoroutine()
    {
        yield return new WaitUntil(() => GetComponent<Button>() == null);
        Button btn = gameObject.AddComponent<Button>();
        btn.onClick.AddListener(showWindow);
    }

    
    void showWindow()
    {
        element.SetActive(true);
        message.text = "You need atleast " + config.minStarToEnter + " stars to enter this stage. You currently have " + getStageScore(config.from, config.to);
    }

    bool isStageNotAccessible()
    {
        return config.minStarToEnter >= getStageScore(config.from, config.to);
    }

    public static int getStageScore(int from, int to)
    {
        int score = 0;
        for(int i = from; i <= to; i++ )
        {
            score += LevelSelector.getRating(i);
        }

        return score;
    }
}
    