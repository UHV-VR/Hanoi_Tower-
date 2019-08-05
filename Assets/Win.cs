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
                Debug.Log("one of them is null");
            }
                 

        }
        if (full)
        {
            
            checkSolution();
        }

        //shouldn' get here
        /*if (gameObject.GetComponent<tower>().order[0].GetComponent<Piece>().tagPosition == 1)
        { 
            if (gameObject.GetComponent<tower>().order[1].GetComponent<Piece>().tagPosition == 2)
            {
                if (gameObject.GetComponent<tower>().order[2].GetComponent<Piece>().tagPosition == 3)
                {
                    FindObjectOfType<AudioManager>().play("winning");
                    Destroy(this);
                }
            }
        }*/
    }
    /*void OnCollisionEnter(Collision other)
    {
       // Debug.Log(" im in the for loop");
        //looks through the the towers interactables 
        for (int i = 0; i < 3; i++)
        {
            //GameObject peice = gameObject.GetComponent<tower>().getElement(i);
            // Debug.Log(peice.GetComponent<Piece>().tagPosition);
            if (gameObject.GetComponent<tower>().order[i] == null)
            {
                solution = 0;
                return;
            }
            // if the element is holding the right peice 
            else if (gameObject.GetComponent<tower>().order[i].GetComponent<Piece>().tagPosition == i + 1)
            {

                gameObject.GetComponent<tower>().order[i].tag = "bases";
                gameObject.GetComponent<tower>().order[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
                solution++;
                return;
            }
            else
            {
                solution = 0;
                return;
            }
               
        }
        checkSolution();
    }*/

   

    void checkSolution()
    {
        Debug.Log("made it inside check solution");
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
