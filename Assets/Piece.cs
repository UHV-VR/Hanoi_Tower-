using System.Collections;
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
            //Debug.Log(colInfo.collider.name);
            //  Debug.Log(hitPos.normal);
            if (collisionInfo.gameObject.GetComponent<Piece>())
            { 
                if (hitPos.normal.y < 0 && (collisionInfo.gameObject.GetComponent<Piece>().tagPosition > tagPosition))
                {
                    gameObject.tag = "bases";

                    /*  Renderer rend = gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();

                      //Set the main Color of the Material to green
                      rend.material.shader = Shader.Find("_Color");
                      rend.material.SetColor("_Color", Color.grey);
                      //Find the Specular shader and change its Color to red
                      rend.material.shader = Shader.Find("Specular");
                      rend.material.SetColor("_SpecColor", Color.grey);
          */
                    gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
                }
            }

        }
        if (collisionInfo.collider.tag == "noninteractable")
        {
            // and it isn't being held by the remote 
            if (rright.GetComponent<Hand>().triggerDown || rleft.GetComponent<Hand>().triggerDown)
            {
               // Debug.Log("can not transform due to being held by remote");
                return;

            }
           //  Debug.Log(" transform to new position");
            //reassigns it to tower 
            Reset();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<Piece>())
        {
            if (other.gameObject.GetComponent<Piece>().tagPosition > tagPosition)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", offColor);
                gameObject.tag = "interactable";
                Debug.Log("im leaving and this is why");
                Debug.Log(other.transform.name);
            }
        }
    }

    void Reset()
    {
        gameObject.transform.position = tower;
        gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    
}
