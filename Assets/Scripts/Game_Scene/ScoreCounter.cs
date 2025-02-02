using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Enables use of uGUI classes like text
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] //allows score field to update during the game
    public int score = 0;
    private TextMeshProUGUI uiText; //stores a reference to text component on ScoreCounter gameobject

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>(); //searches object that ScoreCounter script is attached to for a text component, then it assigns that text component to uiText
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString( "#,0"); //This 0 is a zero, returns score value as a string, with a , seperating every 3 digits
    }
}
