using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public List<VideoItem> videos;
    public VideoPlayer videoPlayer;

    public static VideoManager getInstance()
    {
        return GameObject.FindGameObjectWithTag("Manager")
        .GetComponent<VideoManager>();
    }

    public void playVideo(string name)
    {
        Time.timeScale = 0;
        videoPlayer.clip = videos.Find(v => v.name.Equals(name))?.video;
        getVideoPanel().SetActive(true);
        videoPlayer.Play();
        videoPlayer.loopPointReached += (VideoPlayer vp) =>
        {
            getVideoPanel().SetActive(false);
            Time.timeScale = 1;
        };
    }

    private GameObject getVideoPanel()
    {
        return videoPlayer.gameObject.transform.parent.gameObject;
    }

    [System.Serializable]
    public class VideoItem
    {
        public string name;
        public VideoClip video;
    }

}
