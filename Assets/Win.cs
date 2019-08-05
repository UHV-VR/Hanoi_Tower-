using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public int solution = 0;
    bool full = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        full = true;
        for(int i = 0; i < gameObject.GetComponent<tower>().order.Length; i ++)
        {
            if (gameObject.GetComponent<tower>().order[i] == null)
            {
                full = false;
               // Debug.Log("one of them is null");
            }
                 
            //MAYBE ADD THAT THE PEICES CHANGE THEIR TAG HERE???
        }
        if (full)
        {
            
            checkSolution();
        }

     
    }
 

   

    void checkSolution()
    {
       // Debug.Log("made it inside check solution");
        for (int i = 0; i < gameObject.GetComponent<tower>().order.Length; i++)
        {
            if (gameObject.GetComponent<tower>().order[i].GetComponent<Piece>().tagPosition == i + 1)
            {

                gameObject.GetComponent<tower>().order[i].tag = "bases";
                gameObject.GetComponent<tower>().order[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
                solution++;
            }

        }

        if (solution == 3)
        {
            //DOUBLE CHECK TO SEE IF THE AUDIO NAME IS CORRECT 
            FindObjectOfType<AudioManager>().play("winning");
            Destroy(this);
        }
        else
            solution = 0;
    }
}
