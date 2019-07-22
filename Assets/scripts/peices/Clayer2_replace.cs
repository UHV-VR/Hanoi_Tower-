using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clayer2_replace : MonoBehaviour
{

    public GameObject replacement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        if ( collision.collider.name == "top_hanoi (1)")
        {
            replacement.transform.position = gameObject.transform.position;
            replacement.SetActive(true);
            gameObject.SetActive(false);
            
        }


    }
}
