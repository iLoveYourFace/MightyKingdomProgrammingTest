using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

//this code is based on the one made by Brackeys
public class SoundManager : MonoBehaviour
{
    //public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    private void Awake()
    {
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            Play("Theme");
            // s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound)
    {
        var s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }
    
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

    [Serializable]
    public class Sound
    {
        public AudioClip clip;

        public bool loop;

        //public AudioMixerGroup mixerGroup;

        public string name;

        [Range(.1f, 3f)] public float pitch = 1f;

        [Range(0f, 1f)] public float pitchVariance = .1f;

        [HideInInspector] public AudioSource source;

        [Range(0f, 1f)] public float volume = .75f;

        [Range(0f, 1f)] public float volumeVariance = .1f;
    }
}