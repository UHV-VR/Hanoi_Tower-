using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSolution : tower
{
    // Start is called before the first frame update
    void Start()
    {

    }

  

    private int solution = 0;

    void Update()

    {
        //looks through the the towers interactables 
        for (int i = 0; i < 4; i++)
        {
            // if the element is holding the right peice 
            if (order[i].GetComponent<Piece>().tagPosition == i + 1)
            {
                order[i].tag = "bases";
                order[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
                solution++;
            }
        }
        checkSolution();
    }


    void checkSolution()

    {
        if (solution == 3)
        {
            //DOUBLE CHECK TO SEE IF THE AUDIO NAME IS CORRECT 
            FindObjectOfType<AudioManager>().play("winning");
        }
    }
}
