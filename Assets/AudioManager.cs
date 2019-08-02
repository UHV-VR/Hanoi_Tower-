using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch; 
        }
    }

    //  plays the audio for name provided 
    public void play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        //  PURHAPS NEED TO DELAY THE IS PLAYING BY RANDOM VALUES??
        //  NEED TO FIGURE THIS OUT!
        if (s == null && !(s.isplaying()))
        {
            Debug.Log("sound: " + name + " is not found ");
            return;
        }
        s.source.Play();
    }
}

            
