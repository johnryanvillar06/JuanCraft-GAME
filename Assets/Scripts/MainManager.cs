using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using static ClipboardController;
using UnityEngine.SceneManagement;
using static LevelSelector;

public class MainManager : MonoBehaviour
{

    public TextMeshProUGUI UITimer; 
    public float timeLimit;
    public delegate void OnTimesUp();
    public event OnTimesUp onTimesUp;

    [Header("Scoreboard")]
    public GameObject scoreboard;
    public GameObject scoreboardContainer;
    public GameObject scoreboardItemPrefab;
    public Button next;
    public TextMeshProUGUI points;
    public int nextLevel;

    [Header("Star Rating")]
    public List<GameObject> stars;

    [SerializeField]
    private float time;

    Coroutine routine;

    // Start is called before the first frame update
    void Start()
    {
        resetTime();
        startTime();
    }

    void resetTime()
    {
        time = timeLimit;
    }

    void startTime()
    {
        routine = StartCoroutine(countDownCoroutine());
    }

    void stopTime()
    {
        StopCoroutine(routine);
    }

    public void stopGame()
    {
        onTimesUp?.Invoke();
        time = 0;
        previewScoreboard();
        stopTime();
        SoundManager.getInstance()?.playOnce("level_complete");
    }


    void previewScoreboard()
    {
        scoreboard.SetActive(true);
        points.SetText(GetComponent<TruckManager>().points.ToString());
        previewSatisfiedDemands();
        previewStarRating();


        if(LevelSelector.evaluateNextStage(PreSetupManager.level, computeStarRating()) && StageLocker.isStageAccessible(PreSetupManager.level))
        {
            next.onClick.AddListener(() => {
                if(!PreSetupManager.isLastLevel())
                {
                    LevelSelector.loadScene(LevelSelector.getGameConfigByLevel(PreSetupManager.level + 1));
                }
            });
        }

    }

  

    void previewSatisfiedDemands()
    {
        List<AssignmentManager.Demand> demands = AssignmentManager.getInstance().demands;
        demands.ForEach((d) => {
            initContainer(scoreboardItemPrefab, scoreboardContainer, new ClipboardDetailStruct(
                d.item.name,
                d.numberOfDemands + " / " + d.satisfied,
                d.item.image,
                () => { }
            ));
        });
    }

    private void previewStarRating()
    {
        int rating = computeStarRating();
        for(int i =0; i < rating; i++)
        {
            stars[i].SetActive(true);
        }
    }

    private int computeStarRating()
    {
        double totalSatisfied = AssignmentManager.getInstance().demands.Sum(d => d.satisfied);
        double totalDemands = AssignmentManager.getInstance().demands.Sum(d => d.numberOfDemands);
        
        if(totalDemands < totalSatisfied)
        {
            totalSatisfied = totalDemands;
        }

        double rating = totalSatisfied / totalDemands * stars.Count;

        return (int)rating;
    }

    IEnumerator countDownCoroutine()
    {
        while (true)
        {
            time -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            //UITimer.SetText("TIME : " +((int)time).ToString("D3"));
            UITimer.SetText(string.Format("TIME: "+ "{0:00}:{1:00}", minutes, seconds));
            if (time < 0)
            {
                stopGame();
                break;
            }

            yield return new WaitForFixedUpdate();
        }
    }

}
