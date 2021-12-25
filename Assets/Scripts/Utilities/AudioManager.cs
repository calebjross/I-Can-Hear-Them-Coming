using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioSource.playOnAwake = false;
        audioClips.Add(AudioClipName.ForestBG,
            Resources.Load<AudioClip>("s_forestBG"));
        audioClips.Add(AudioClipName.ForestBGPostBlood,
            Resources.Load<AudioClip>("s_forestBG_postblood"));
        audioClips.Add(AudioClipName.HouseBG,
            Resources.Load<AudioClip>("s_houseBG"));
        audioClips.Add(AudioClipName.KeyPickup,
            Resources.Load<AudioClip>("s_key-pickup"));
        audioClips.Add(AudioClipName.OpenDoor,
            Resources.Load<AudioClip>("s_open-door"));
        audioClips.Add(AudioClipName.LockedDoor,
            Resources.Load<AudioClip>("s_locked-door"));
        audioClips.Add(AudioClipName.ToiletMove,
            Resources.Load<AudioClip>("s_toilet-move"));
        audioClips.Add(AudioClipName.PaperOpen,
            Resources.Load<AudioClip>("s_paper-open"));
        audioClips.Add(AudioClipName.PaperClose,
            Resources.Load<AudioClip>("s_paper-close"));
        audioClips.Add(AudioClipName.AlternateOpenClose,
            Resources.Load<AudioClip>("s_dialog"));
        audioClips.Add(AudioClipName.HorrorStinger,
            Resources.Load<AudioClip>("s_horror-stinger"));
        audioClips.Add(AudioClipName.StepA,
            Resources.Load<AudioClip>("s_footstepA"));
        audioClips.Add(AudioClipName.StepB,
            Resources.Load<AudioClip>("s_footstepB"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name, float volume, bool loop = false)
    {
        if (loop == false)
        {
            audioSource.PlayOneShot(audioClips[name], volume);
        }
        else if (loop == true)
        {
            audioSource.clip = audioClips[name];
            audioSource.volume = volume;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public static void StopPlay(AudioClipName name)
    {
        audioSource.Stop();
    }
}

