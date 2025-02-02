using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BasketController : MonoBehaviour
{
    public ScoreCounter scoreCounter; // stores a reference to the instance of scorecounter script that is attached to scorecounter object
    public int roundcnt = RoundCounter.roundcnt;

    void Start()
    {
        //Find a gameobject named scorecounter in the hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get scorecounter script component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();    
    }

    
    void Update()
    {
       //Get current screen position of the mouse from Input
       Vector3 mousePos2D = Input.mousePosition;

       //The cameras z position sets how far to push the mouse into 3D
       //If this line causes a NullReferenceException, select main camera 
       //in hierarchy and set its tag to MainCamera in the inspector

       mousePos2D.z = -Camera.main.transform.position.z;

       //Convert the point from 2D screen space into 3D game world space;
       Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

       //Move baskets x pos to mouse x position
       Vector3 pos = this.transform.position;
       pos.x = mousePos3D.x;
       this.transform.position = pos; 
    }

    void OnCollisionEnter ( Collision coll ) { //called whenever another object collides w/ basket
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject; // assigns colliding gameobject to temp variable collidedWith
        if (collidedWith.CompareTag("Apple")) { //checks to see if colliding object is an apple by tag, if apple hits basket, its destroyed
            Destroy ( collidedWith);
            scoreCounter.score += 100; //Increases score
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
        }
        else if (collidedWith.CompareTag("Branch")) {
            Destroy (collidedWith);
            SceneManager.LoadScene("_Game_Over");
        }
    }
}
