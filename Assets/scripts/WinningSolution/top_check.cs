using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top_check : MonoBehaviour
{

    public AudioClip win;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "top_hanoi (1)" && WorldVariables.winningSolution == 2)
        {
            WorldVariables.winningSolution++;
            if (!audiosource.isPlaying)
            {
                audiosource.PlayOneShot(win, .2f);
            }
        }
    }
}
