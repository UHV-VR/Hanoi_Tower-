//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;

public class on_off_interaction : MonoBehaviour
{

    public GameObject replacement;

    public AudioClip wrongSound;
    public AudioClip correct;
    AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    private void update()
    {

    }
    private void OnCollisionEnter(Collision colInfo)
    {

        foreach (ContactPoint hitPos in colInfo.contacts)
        {
            //Debug.Log(colInfo.collider.tag);
            // Debug.Log(hitPos.normal);
            if (hitPos.normal.y < 0 && (colInfo.collider.name == "middle_hanoi (1)" || colInfo.collider.name == "top_hanoi (1)"))
            {
                replacement.transform.position = gameObject.transform.position;
                replacement.SetActive(true);

                gameObject.SetActive(false);
            }
            if (hitPos.normal.y > 0 && (colInfo.collider.name == "middle_hanoi (1)" || colInfo.collider.name == "top_hanoi (1)"))
            {

                // Debug.Log("executed top layer of layer 000");
                if (!audiosource.isPlaying)
                {
                    audiosource.PlayOneShot(wrongSound, .2f);
                }


            }
            else if (colInfo.collider.tag == "bases")
            {
                if (!audiosource.isPlaying)
                {
                    audiosource.PlayOneShot(correct, .2f);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bottomCol")
        {

        }
    }
}
