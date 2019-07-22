using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseInteraction : MonoBehaviour
{
    //serialized fields are private but show in the inspector
    [SerializeField]

    private float Opacity = 0.5f;
    GameObject child;

    // the different colors of when it is seethough and when it is not 
    private Color seethroughColor;
    private Color opaqueColor;

    // Start is called before the first frame update
    void Start()
    {
        seethroughColor = new Color();
        seethroughColor = gameObject.GetComponentInChildren<Renderer>().material.color;
        seethroughColor.a = Opacity;

        opaqueColor = seethroughColor;
        opaqueColor.a = 1;
        child = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!WorldVariables.triggerDown)
        {
            
            child.GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
        }
    }

    //on trigger state

    void OnTriggerStay(Collider other)
    {

        //  print("is interacting with the trigger");
        //  Debug.Log(other.tag);
        WorldVariables.towerpresent = gameObject.transform.GetChild(1).position;
        WorldVariables.inRange = true;
        if (WorldVariables.triggerDown && other.name == WorldVariables.heldName)
        {
            //      print("is interacting with the trigger within the if ");
           // GetComponent<Renderer>().material.SetColor("_Color", seethroughColor);
            child.GetComponent<Renderer>().material.SetColor("_Color", seethroughColor);
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "interactable")
        {
            child.GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
            WorldVariables.inRange = false;
        }

    }
}
