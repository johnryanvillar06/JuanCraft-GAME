using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public const string SETTINGS_SFX = "SETTINGS_SFX";
    public const string SETTINGS_MUSIC = "SETTINGS_MUSIC";

    public Slider sfx, music; 
    
    // Start is called before the first frame update
    void Start()
    {
        sfx.onValueChanged.AddListener(v => PlayerPrefs.SetFloat(SETTINGS_SFX, v));
        music.onValueChanged.AddListener(v => PlayerPrefs.SetFloat(SETTINGS_MUSIC, v));

        sfx.value = PlayerPrefs.GetFloat(SETTINGS_SFX, 1);
        music.value = PlayerPrefs.GetFloat(SETTINGS_MUSIC, 1);
    }

    public static bool isReady()
    {
        return GameObject.FindGameObjectWithTag("Manager")?
            .GetComponent<Settings>() != null;
    }

    public static void attachListener(string setting, AudioSource source)
    {
        Settings s = GameObject.FindGameObjectWithTag("Manager")
            .GetComponent<Settings>();

        switch (setting)
        {
            case SETTINGS_SFX:
                s.sfx.onValueChanged.AddListener(v => {
                    if(source == null)
                    {
                        return;
                    }
                    source.volume = v;
                });
                break;
            case SETTINGS_MUSIC:
                s.music.onValueChanged.AddListener(v => source.volume = v);
                break;
        }

        source.volume = PlayerPrefs.GetFloat(setting, 1);
    }

}
