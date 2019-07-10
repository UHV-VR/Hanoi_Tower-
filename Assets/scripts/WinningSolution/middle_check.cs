using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middle_check : MonoBehaviour
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "middle_hanoi (1)" && WorldVariables.winningSolution == 1)
        {
            replacement.transform.position = other.transform.position;
            replacement.SetActive(true);
            other.gameObject.SetActive(false);
            WorldVariables.winningSolution++;
        }
    }
}
