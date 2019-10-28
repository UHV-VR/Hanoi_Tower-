﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Vector3 tower;
    public int tagPosition;

    private Color seethroughColor;
    private Color offColor;

    //[SerializeField]
    public GameObject rright;

   // [SerializeField]
    public GameObject rleft;

    
    // Start is called before the first frame update
    void Start()
    {
        seethroughColor = new Color();
        seethroughColor = gameObject.GetComponentInChildren<Renderer>().material.color;
        offColor = seethroughColor;
        tower = GameObject.Find("tower_1").transform.GetChild(0).position;
       // towers = GameObject.FindGameObjectsWithTag("bases");
       // rleft = GameObject.Find("Controller (left)");
       // rright = GameObject.Find("Controller(right)");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        foreach (ContactPoint hitPos in collisionInfo.contacts)
        {
           // Debug.Log(collisionInfo.collider.name);
            //  Debug.Log(hitPos.normal);

            //sees if the collider is an interactable piece
            //if (collisionInfo.gameObject.GetComponent<Piece>())
            //  THIS IS THE NEW SCRIPT TO TRY 
            if(collisionInfo.transform.CompareTag("interactable"))
            { 
                //if the collision is happening on the bottom
                if (hitPos.normal.y < 0 && (collisionInfo.gameObject.GetComponent<Piece>().tagPosition > tagPosition))
                {
                    gameObject.tag = "bases";

                    gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
                    // gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;

                    //ADDED HERE!
                    //gameObject.tag = "noninteractable";
                    gameObject.GetComponent<Interactable>().enabled = false;
                }
            }

        }
        //sees if it is colliding with something its not supose to
        //NEW CODE HERE AS WELL 
        if (collisionInfo.transform.CompareTag ("noninteractable"))
        {
            // and it isn't being held by the remote 
            if (rright.GetComponent<Hand>().triggerDown || rleft.GetComponent<Hand>().triggerDown)
            {
                Debug.Log("can not transform due to being held by remote");
                return;

            }
            // Debug.Log(" transform to new position");
            //reassigns it to the last known tower 
            move(tower);
        }
       
       
    }

    void OnCollisionExit(Collision other)
    {
        
        //sees if the collider leaving is a piece 
         if (other.gameObject.GetComponent<Piece>())
         {
             // sees if it is a piece that is smaller 
             if (other.gameObject.GetComponent<Piece>().tagPosition > tagPosition)
             {
                if ((rright.GetComponent<Hand>().held == other.gameObject.name || rleft.GetComponent<Hand>().held == other.gameObject.name))
                {
                
                 gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", offColor);
                 gameObject.tag = "interactable";
                 //gameObject.GetComponent<Rigidbody>().isKinematic = false;
                 gameObject.GetComponent<Interactable>().enabled = true;

                }
                 gameObject.GetComponent<Interactable>().enabled = true;
                 // Debug.Log("im leaving and this is why");
                 //  Debug.Log(other.transform.name);
             }
         }

    }
 
    //moves the peice to the provided position 
    public void move(Vector3 pos)
    {
        gameObject.transform.position = pos;
        gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
    //sets the new known tower position 
    public void setTower(Vector3 pos)
    {
        tower = pos;
    }
    //resets the peice to the known  tower 
    public void reset()
    {
        move(tower);
    }
    

}
