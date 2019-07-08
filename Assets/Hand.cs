using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    //used for picking up and droping the object
    public SteamVR_Action_Boolean m_GrabAction = null;

    //used to attach to controller 
    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_joint = null;

    //what our controller is currently holding or interacting with 
    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractable = new List<Interactable>();
    //change this to private later!!

    // m = movement 
    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_joint = GetComponent<FixedJoint>();
    }
    // Update is called once per frame
    void Update()
    {
        //the trigger is being held down 
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            // print(m_Pose.inputSource + "Trigger Down");
            pickup();
        }

        //up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            // print(m_Pose.inputSource + "Trigger Up");
            Drop();
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////
    //collider is the sphere attached to the controller 
    //adds and removes how many interactables are within range of the remote/ sphere collider 
    /////////////////////////////////////////////////////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("interactable"))
        {
            return;
        }
        m_ContactInteractable.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("interactable"))
        {
            return;
        }
        m_ContactInteractable.Remove(other.gameObject.GetComponent<Interactable>());

    }
    /// <summary>
    /// adds and removes objects from the remote
    /// uses a joint to join the remote to the object
    /// </summary>
    public void pickup()
    {
        // sets the static to true 
        WorldVariables.triggerDown = true;

        //get nearest 
        m_CurrentInteractable = GetNearestInteractable();
        //null check 
        if (!m_CurrentInteractable)
        {
            return;
        }
        //already held, check
        if (m_CurrentInteractable.m_ActiveHand)
        {
            m_CurrentInteractable.m_ActiveHand.Drop();
        }
        //position to controller 
        m_CurrentInteractable.transform.position = transform.position;

        //attach
        Rigidbody targetbody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_joint.connectedBody = targetbody;

        //set active hand 
        m_CurrentInteractable.m_ActiveHand = this;
    }

    public void Drop()
    {
        // sets the static to false
        WorldVariables.triggerDown = false;

        //null check
        if (!m_CurrentInteractable)
        {
            return;
        }

        //apply velocity
        Rigidbody targetbody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetbody.velocity = m_Pose.GetVelocity();
        targetbody.angularVelocity = m_Pose.GetAngularVelocity();

        // TRYING TO RESET THE ROTATION OF THE OBJECT BEFORE IT IS SET TOWN ON A TOWER 
        targetbody.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //detach 
        m_joint.connectedBody = null;

        //clear 
        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;
    }
    /// <summary>
    ///  want to get the nearest interactable object to the remote 
    /// </summary>
    /// <returns></returns>

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;
        foreach (Interactable interactable in m_ContactInteractable)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }
        return nearest;
    }
}

