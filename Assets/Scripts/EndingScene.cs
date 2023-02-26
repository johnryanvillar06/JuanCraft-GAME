using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingScene : MonoBehaviour
{

    public GameObject[] Platforms;

    public List<GameObject> PlatformToSpawn;

    public float platformSpawnInteral;

    public VideoPlayer videoPlayer;
    public GameObject videoPlayerPanel;

    public AudioSource audio;

    public int count = 0;

    void Start()
    {
        Platforms[0].SetActive(true);
        StartCoroutine(AddPlatformTimer());
    }
    IEnumerator AddPlatformTimer()
    {
        for (int i = 0; i < Platforms.Length; i++)
        {
            next();
            yield return new WaitForSeconds(platformSpawnInteral);
        }
    }
    public void next()
    {
        videoPlayer.started += (VideoPlayer vp) =>
        {
            audio.Pause();
            Time.timeScale = 0;
        };
        videoPlayer.loopPointReached += (VideoPlayer vp) =>
        {
            Time.timeScale = 1;
            audio.Play();
            videoPlayerPanel.SetActive(false);
        };

        PlatformToSpawn.Add(Platforms[count]);
        Platforms[count].SetActive(true);
        count++;
    }

}
