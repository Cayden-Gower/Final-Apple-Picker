using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI _UI_TEXT;
    static private int _SCORE = 1000;

    private Text txtCom; //txtCom is a reference to this GO's Text component
    
    void Awake () {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();

        //If PlayerPrefs Highscore already exists, read it
        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        //Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE {
        get {return _SCORE;}
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null ) {
                _UI_TEXT.text = "High Score: " + value.ToString( "#,0" );
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE (int scoreToTry) { //public function so it can be accessed across classes
        if ( scoreToTry <= SCORE ) 
            return; 
        SCORE = scoreToTry;
    }

    //This code allows you to easily reset the PlayerPrefs Highscore
    [Tooltip( "Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnValidate() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt( "HighScore", 0 );
            Debug.LogWarning("PlayerPrefs Highscore reset to 1,000.");
        }
    }
}
