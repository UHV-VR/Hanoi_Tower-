using System.Collections;
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
    public GameObject rright;

    // [SerializeField]
    public GameObject rleft;

    private bool inrange = false;
    private string inrangename = "null";

    private Vector3 tip;
    //can get rid of???

    //keeps the order of the pieces the tower interacts with 
    private int[] order = new int[] { 5, 5, 5, 5 };

    // Start is called before the first frame update
    void Start()
    {
        seethroughColor = new Color();
        seethroughColor = GetComponent<Renderer>().material.color;
        seethroughColor.a = Opacity;

        opaqueColor = seethroughColor;
        opaqueColor.a = 1;
        tip = gameObject.transform.GetChild(0).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if ((rright.GetComponent<Hand>().triggerDown || rleft.GetComponent<Hand>().triggerDown) && (rright.GetComponent<Hand>().held == other.name || rleft.GetComponent<Hand>().held == other.name))
        {
            // Debug.Log("inside getting ready to change color");
            GetComponent<Renderer>().material.SetColor("_Color", seethroughColor);
            inrange = true;
            inrangename = other.name;

        }
        if ((!rright.GetComponent<Hand>().triggerDown && !rleft.GetComponent<Hand>().triggerDown) )
        {
           
            if (inrange && other.name == inrangename)
            {
                other.GetComponent<Piece>().move(tip);
                other.GetComponent<Piece>().setTower(tip);
                GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
                inrange = false; 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "interactable")
        {
            GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
            inrange = false; 
        }

    }

    //DONT DO THIS HERE! DO THIS IN TRIGGER STAY WITH  if (inrange && other.name == inrangename)
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "interactable")
        {
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] == 5)
                {
                    if (order[i - 1] < other.collider.GetComponent<Piece>().tagPosition)
                    {
                        other.collider.GetComponent<Piece>().reset();
                    }
                }
            }
        }
    }
}
