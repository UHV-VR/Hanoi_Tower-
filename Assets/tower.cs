﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    //serialized fields are private but show in the inspector
    [SerializeField]

    private float Opacity = 0.5f;

    // the different colors of when it is seethough and when it is not 
    private Color seethroughColor;
    private Color opaqueColor;

    //[SerializeField]
    //holds the right remote 
    public GameObject rright;

    // [SerializeField]
    //holds the left remote 
    public GameObject rleft;

    //tells us if the object that the remote has is in range and what its name is 
   
    private bool inrange = false;
    private string inrangename = "null";

    private Vector3 tip;
    //can get rid of???

    //keeps the order of the pieces the tower interacts with 
    public GameObject[] order = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        seethroughColor = new Color();
        seethroughColor = GetComponent<Renderer>().material.color;
        seethroughColor.a = Opacity;

        opaqueColor = seethroughColor;
        opaqueColor.a = 1;
        tip = gameObject.transform.GetChild(0).transform.position;
        for(int i = 0; i < 3; i++)
        {
            order[i] = null;    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //checks the trigger space everytime the physics update 
    void OnTriggerStay(Collider other)
    {
        if ((rright.GetComponent<Hand>().triggerDown || rleft.GetComponent<Hand>().triggerDown) && (rright.GetComponent<Hand>().held == other.name || rleft.GetComponent<Hand>().held == other.name))
        {
            // Debug.Log("inside getting ready to change color");
            //GetComponent<Renderer>().material.SetColor("_Color", seethroughColor);
            SetOpaque(seethroughColor);
            inrange = true;
            inrangename = other.name;

        }
        if ((!rright.GetComponent<Hand>().triggerDown && !rleft.GetComponent<Hand>().triggerDown))
        {
            //checks to see if inrange is true and the collider with the trigger is what WAS held by the remote   
            if (inrange && other.name == inrangename)
            {
                check(other);
            }
        }
        
       
    }

    //checks to see if the peice follows the rules if placed on this tower 
    private void check(Collider other)
    {
        //looks through the array of objects that are colliding with the tower
        for (int i = 0; i < order.Length; i++)
        {
           // Debug.Log("is in loop on " + i + " itteration");
           // Debug.Log(i + " element is " + order[i]);
            //looks for first empty object 
            if (order[i] == null)
            {
               // Debug.Log("content of i is 5");
                // sees if the element before it has an object that is smaller 
                if (i == 0)
                {
                    //Debug.Log("i is 0");
                    MoveToTower(other, i);
                    inrangename = "null";
                    FindObjectOfType<AudioManager>().play("correct");
                    return;
                }
                //sees if the peice below the found element is smaller than the peice we have 
                else if (order[i - 1].GetComponent<Piece>().tagPosition > other.GetComponent<Collider>().GetComponent<Piece>().tagPosition)
                {
                   // Debug.Log("the element below i is too small");
                    //resets the peice to its last known tower 
                    other.GetComponent<Collider>().GetComponent<Piece>().reset();
                    FindObjectOfType<AudioManager>().play("wrong");
                    return;
                }
                else
                {
                   // Debug.Log("inside the else");
                    MoveToTower(other, i);
                    inrangename = "null";
                    FindObjectOfType<AudioManager>().play("correct");
                    return;
                }
            }
        }
    }

    //when an object leaves the trigger space, resets the towers color and removes the peice from the array of colliding objects 
    void OnTriggerExit(Collider other)
    {
        inrange = false;
        if (other.tag == "interactable")
        {
           // GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
            SetOpaque(opaqueColor);
            
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] == null)
                {
                    return;
                }
                if (other.GetComponent<Piece>().tagPosition == order[i].GetComponent<Piece>().tagPosition)
                {
                    order[i] = null;
                    return;
                }
            }

        }

    }

    //sets the opacity of the tower 
    void SetOpaque(Color change)
    {
        GetComponent<Renderer>().material.SetColor("_Color", change);
    }
    //moves the tower to provided position
    void MoveToTower(Collider other, int element)
    {
        other.GetComponent<Piece>().move(tip);
        other.GetComponent<Piece>().setTower(tip);
        GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
        inrange = false;

        order[element] = other.gameObject;

    }

   public GameObject getElement(int element)
    {
        return order[element];
    }
    public bool getInRange()
    {
        return inrange;
    }

  
}
