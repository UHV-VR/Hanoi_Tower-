using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldVariables
{
    public static Vector3 towerpast = new Vector3(-.00666f, 2.46f, -.0133f);
    public static Vector3 towerpresent = new Vector3(-.00666f, 2.46f, -.0133f);

    // to see if the remote trigger is pressed 
    //is pressed 
    public static bool triggerDown = false;

    //holds the name of the object currently being held by the remote 
    public static string heldName = "null";

    public static bool inRange = false;
    public static int winningSolution = 0;
}