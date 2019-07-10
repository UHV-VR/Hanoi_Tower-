using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer2_on_off : MonoBehaviour
{

    public GameObject replacement;

    public AudioClip wrongSound;
    AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    //sees if the collision with a smaller peice 
    private void OnCollisionEnter(Collision colInfo)
    {

        //looks for the direciton of the collision 
        foreach (ContactPoint hitPos in colInfo.contacts)
        {
            
         //   Debug.Log(colInfo.collider.tag);
         //  Debug.Log(hitPos.normal);
            if (hitPos.normal.y < 0 &&  colInfo.collider.name == "top_hanoi (1)")
            {
                replacement.transform.position = gameObject.transform.position;
                replacement.SetActive(true);

                gameObject.SetActive(false);
            }
            // checks to see if there is a smaller peice below it 
            if (hitPos.normal.y > 0 && colInfo.collider.name == "top_hanoi (1)")
            {
                if (!WorldVariables.triggerDown)
                {
                    //Debug.Log("executed top layer of layer 002");
                    if (!audiosource.isPlaying)
                    {
                        audiosource.PlayOneShot(wrongSound, .2f);
                    }
                    gameObject.transform.position = WorldVariables.towerpast;
                }
            }
        }
     
      

    }
  

}
