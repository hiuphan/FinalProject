using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (sounds == null || sounds.Length == 0)
        {
            Debug.LogWarning("No sounds assigned to the AudioManager.");
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;

            if (s.mixerGroup != null)
            {
                s.source.outputAudioMixerGroup = s.mixerGroup;
            }
        }

        PlaySound("MainTheme"); 
    }

    public void PlaySound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + name);
        }
    }

    public void StopSound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Stop();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + name);
        }
    }
}
