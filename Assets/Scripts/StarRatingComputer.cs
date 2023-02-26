using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRatingComputer : MonoBehaviour
{
    public int from = 1;
    public int to = 5;


    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        for(int level = from; level <= to; level++)
        {
            score += PlayerPrefs.GetInt("level_star" + level, 0);
        }

        GetComponent<Text>().text = score + "/15";
    }

}
