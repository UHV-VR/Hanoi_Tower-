using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchBase : MonoBehaviour
{
    //attached to object 

    /// <summary>
    /// will reset the object to last known tower if landing on something other than a base
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision other)

    {
        //if its touching something other than a base
        if (other.collider.tag == "noninteractable")
        {
            // and it isn't being held by the remote 
            if (WorldVariables.triggerDown)
            {
                //Debug.Log("can not transform due to being held by remote");
                return;

            }
            Debug.Log(" transform to new position");
            gameObject.transform.position = WorldVariables.towerpast;
            gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            Rigidbody reset = gameObject.GetComponent<Rigidbody>();
            //does not work??
            reset.angularVelocity = Vector3.zero;
            reset.velocity = Vector3.zero;
        }

    }
}
