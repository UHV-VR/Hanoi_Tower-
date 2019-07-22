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

    // Start is called before the first frame update
    void Start()
    {
        seethroughColor = new Color();
        seethroughColor = GetComponent<Renderer>().material.color;
        seethroughColor.a = Opacity;

        opaqueColor = seethroughColor;
        opaqueColor.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if ((!rright.GetComponent<Hand>().triggerDown || !rleft.GetComponent<Hand>().triggerDown) && (rright.GetComponent<Hand>().held == other.name || rleft.GetComponent<Hand>().held == other.name))
        {
             Debug.Log("inside getting ready to change color");
            GetComponent<Renderer>().material.SetColor("_Color", seethroughColor);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "interactable")
        {
            GetComponent<Renderer>().material.SetColor("_Color", opaqueColor);
        }

    }
}
