using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>

public class PlaySceneSounds : MonoBehaviour
{

    #region Fields
    int sceneInt;
    AudioSource audioSource;

    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        sceneInt = SceneManager.GetActiveScene().buildIndex;
        audioSource = GameObject.Find("GameAudioSource").GetComponent<AudioSource>();

        //sets audio BG
        switch (sceneInt)
        {
            case 0:
                AudioManager.Play(AudioClipName.ForestBG, .7f, true); ;
                break;
            case 1:
                if (audioSource.clip.name == "s_houseBG")
                {
                    AudioManager.Play(AudioClipName.ForestBG, .7f, true);
                }
                break;
            case 2:
                if (audioSource.clip.name != "s_houseBG")
                {
                    AudioManager.Play(AudioClipName.HouseBG, .5f, true);
                }
                break;
        }
    }
}
    #endregion
