using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool isplaying()
    {
        return (source.isPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
