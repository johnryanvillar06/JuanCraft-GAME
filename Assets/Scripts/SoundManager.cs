using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SoundManager : MonoBehaviour
{

    public List<AudioItem> audios;
    public List<AudioSource> uniqueSounds;

    public static SoundManager getInstance()
    {
        return GameObject.FindGameObjectWithTag("Manager")
        .GetComponent<SoundManager>();
    }

    public void playSound(string name)
    {
        StartCoroutine(generateUniqueSource(name));
    }

    public void playOnce(string name)
    {
        StartCoroutine(generateSource(name));
    }

    private IEnumerator generateSource(string name)
    {
        yield return new WaitUntil(() => Settings.isReady());

        AudioItem item = audios.Find(v => v.name.Equals(name));
        AudioSource audio = createAudio(item);

        yield return new WaitUntil(() => !audio.isPlaying);

        Destroy(audio);
    }

    public void stopSound(string name)
    {
        AudioItem item = audios.Find(v => v.name.Equals(name));
        if(item?.source != null)
        {
            item.source.Stop();
        }
    }

    public IEnumerator generateUniqueSource(string name)
    {
        yield return new WaitUntil(() => Settings.isReady());

        createSource(name);
    }

    public void createSource(string name)
    {

        AudioItem item = audios.Find(v => v.name.Equals(name));

        if(item?.source != null)
        {
            if (!item.source.isPlaying)
            {
                item.source.Play();
            }
            return;
        }

        AudioSource source = createAudio(item);

        source.loop = true;
        item.source = source;
    }

    public AudioSource createAudio(AudioItem item)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        Settings.attachListener(Settings.SETTINGS_SFX, source);
        source.clip = item.audio;
        source.Play();

        return source;
    }

    [System.Serializable]
    public class AudioItem
    {
        public string name;
        public AudioClip audio;
        public AudioSource source;
    }

}
