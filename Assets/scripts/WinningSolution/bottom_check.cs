using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottom_check : MonoBehaviour
{
   public GameObject collide;
    public GameObject replacement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if( other.name == "bottom_hanoi (1)")
            {
            replacement.transform.position = collide.transform.position;
            replacement.SetActive(true);
            collide.SetActive(false);
            WorldVariables.winningSolution++;
        }
    }
}
