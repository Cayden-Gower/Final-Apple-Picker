using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AppleController : MonoBehaviour
{
    public static float bottomY = -20f; //static - shared by all instances of a class, if changed, it will be changed for all objects created from that class

    //Start() unneeded

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
            Destroy ( this.gameObject );
        
            //Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); //gets reference to applepicker script component on main camera
            //Call public AppleMissed() method of apScript
            apScript.AppleMissed();
        }
    }
}
