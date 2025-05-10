using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public bool loop = false;

    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource source;
}
