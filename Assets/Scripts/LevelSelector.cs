using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using static PreSetupManager;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public bool unlockLevel = false;
    public GameConfig config;
    public List<GameObject> starRating;

    public static int starRateToPass = 2;
    public static List<GameLevel> list = new List<GameLevel>();


    public void Start()
    {
        initStarRating();
        initLevelStatus();

        if(getGameConfigByLevel(level).level == 0)
        {
            Debug.Log("Power");
            list.Add(new GameLevel(config, level));
        }
    }

    public static GameLevel getGameConfigByLevel(int level)
    {
        return list.Find(l => l.level == level);
    }


    private void initStarRating()
    {
        for (int i = 0; i < getRating(level); i++)
        {
            starRating[i].SetActive(true);
        }
    }

    private void initLevelStatus()
    {
        if(level > getLevelStatus() && !unlockLevel)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GetComponent<Button>().enabled = false;
        }else
        {
            GetComponent<Button>().onClick.AddListener(() => loadScene(new GameLevel(config, level)));
        }
    }

    public static void loadScene(GameLevel game)
    {
        PreSetupManager.config = game.config;
        PreSetupManager.level = game.level;

        if (PlayerPrefs.GetInt("level_status") == 0 && PlayerPrefs.GetInt("tutorialset") == 0)
        {
            SceneManager.LoadScene("Tutorial");
            PlayerPrefs.SetInt("tutorialset", 1);
        }
        else
        {
            SceneManager.LoadScene("Stage");
        }
    }

    public static int getRating(int level)
    {
        return PlayerPrefs.GetInt("level_star" + level, 0);
    }

    public static int getLevelStatus()
    {
        return PlayerPrefs.GetInt("level_status", 1);
    }

    public static void saveRating(int level, int rating)
    {
        PlayerPrefs.SetInt("level_star" + level, rating);
    }

    public static void incrementLevelStatus(int level)
    {
        int status = getLevelStatus();
        if (level == status)
        {
            PlayerPrefs.SetInt("level_status", status + 1);
        }
    }

    public static bool evaluateNextStage(int level, int rating)
    {
        saveRating(level, rating);
        if (rating >= starRateToPass)
        {
            incrementLevelStatus(level);
            return true;
        }

        return false;
    }



    public struct GameLevel
    {
        public GameConfig config;
        public int level;

        public GameLevel(GameConfig config, int level)
        {
            this.config = config;
            this.level = level;
        }

    }




}
