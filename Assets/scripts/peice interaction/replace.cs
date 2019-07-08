using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replace : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject replacement;
    void Update()
    {
       // Collision collision;


    }
    public void OnCollisionExit(Collision collision)
    {
       // Debug.Log(collision.collider.tag);
         if ( collision.collider.name == "middle_hanoi (1)" || collision.collider.name == "top_hanoi (1)")
          {
              replacement.transform.position = gameObject.transform.position;
              replacement.SetActive(true);
              gameObject.SetActive(false);
           // Debug.Log("running with in replacement of bottom peice");
        }
        
     


    }
}
