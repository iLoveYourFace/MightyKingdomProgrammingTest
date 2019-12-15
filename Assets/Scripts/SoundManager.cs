using System;
using UnityEngine;
using Random = UnityEngine.Random;

//This code is based on the one made by Brackeys
//It plays from a list of sounds that can be called and their pitch and volume modified
public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    //Initiate the list of sounds with the settings we have set in its class
    private void Awake()
    {
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            Play("Theme");
        }
    }

    //Play a selected sound
    public void Play(string sound)
    {
        var s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.pitch = s.pitch * (1f + Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        s.source.Play();
    }
    
    //Change a selected sound's pitch
    public void ChangePitch(string sound, float audioPitch)
    {
        var s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
        s.source.pitch = audioPitch * (1f + Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
    }
    
    //Stop a selected sound
    public void StopSound(string sound)
    {
        var s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
        s.source.Stop();
    }

    //Sound clip's settings
    [Serializable]
    public class Sound
    {
        public AudioClip clip;
        public bool loop;
        public string name;

        [Range(.1f, 3f)] public float pitch = 1f;
        [Range(0f, 1f)] public float pitchVariance = .1f;
        [HideInInspector] public AudioSource source;
        [Range(0f, 1f)] public float volume = .75f;
    }
}