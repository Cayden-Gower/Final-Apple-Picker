using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Enables use of uGUI classes like text
using TMPro;
using static ScoreCounter;
using static AppleTreeController;


public class RoundCounter : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int roundcnt = 1;
    private TextMeshProUGUI roundText;


    void Start()
    {
        roundText = GetComponent<TextMeshProUGUI>();
        
        GameObject scoreGO = GameObject.Find("ScoreCounter");//Find a gameobject named scorecounter in the hierarchy
        scoreCounter = scoreGO.GetComponent<ScoreCounter>(); //Get scorecounter script component of scoreGO
    }

    // Update is called once per frame
    void Update()
    {
        //Increase round count by 1 each 1000 points
        if (scoreCounter.score <= 1000) {
            return;
        }
        if (scoreCounter.score >= 1000 && roundcnt == 1){
            roundcnt++;
        } 
        if (scoreCounter.score >= 2000 && roundcnt == 2){
            roundcnt++;
        }
        if (scoreCounter.score >= 3000 && roundcnt == 3){            
            roundcnt++;
        }
        if (scoreCounter.score > 4000 && roundcnt == 4){
            SceneManager.LoadScene("_Winner_Scene");
        }
        roundText.text = "Round: " + roundcnt.ToString( "#");
    }
}
