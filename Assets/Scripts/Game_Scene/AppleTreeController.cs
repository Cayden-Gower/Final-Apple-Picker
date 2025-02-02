using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AppleTreeController : MonoBehaviour
{
    [Header("Dynamic")]               //Compiler attribute that tells unity to place "inscribed" above following field in inspector for this script
                                        //Inscribed means script will not change while it is running
                                        //These attributes can be seen and adjusted in Unity Inspector on AppleTree object under apple tree script
    //Prefab for Instantiating Apples and Branches
    public GameObject applePrefab;
    public GameObject branchPrefab;

    //Spead at which AppleTree moves
    public float speed = 25f; 

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;
    public float branchDropDelay = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        branchDropDelay = Random.Range(5f, 10f);
        //Start dropping apples
        Invoke( "DropApple", appleDropDelay ); //calls the function DropApple() every 2s
        Invoke( "DropBranch", branchDropDelay);
    }

    
    void DropApple() {
        GameObject apple = Instantiate<GameObject>( applePrefab ); //creates an instance of apple prefab and assigns to GameObject apple
        apple.transform.position = transform.position; //Default position of new object is position stored in prefab (connected to AppleTree, so position of AppleTree)
        Invoke ( "DropApple", appleDropDelay ); //call function again, this time waiting appledropdelay seconds, set in the inspector
    }

    void DropBranch() {
            GameObject branch = Instantiate<GameObject>( branchPrefab ); //creates branch
            branch.transform.position = transform.position; //sets branch position to default position (AppleTree)
            Invoke ("DropBranch", branchDropDelay); //calls again waiting delay seconds
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position; //gets position of tree currently
        pos.x += speed * Time.deltaTime; //changes x position (moves tree right by deltaTime, a measure of # of seconds since last frame)
        transform.position = pos; //moves appletrees position to the new calculated position
        
        //Changing Direction
        if ( pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs( speed ); //Move Right
        }
        else if ( pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs ( speed); //Move left
        }
        //else if ( Random.value < changeDirChance) { // Randomly changes direction
        //    speed *= -1; // Change Direction
        //} //THIS DOES NOT WORK W FAST COMPUTERS, TIME BASED GAMES VARY BASED ON PC SPECS -- MOVE TO FIXED UPDATE
    }

    void FixedUpdate() {
        //Random direction changes are now time-based due to fixedupdate()
        if ( Random.value < changeDirChance) {
            speed *= -1; // Change direction
        }
    }
}
