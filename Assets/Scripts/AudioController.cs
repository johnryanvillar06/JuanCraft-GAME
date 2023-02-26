using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource source;

    public void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(waitTillRead());
    }

    IEnumerator waitTillRead()
    {
        yield return new WaitUntil(() => Settings.isReady());
        Settings.attachListener(Settings.SETTINGS_SFX, source);
    }

}
