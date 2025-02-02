using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour
{
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ChangeScene() {
        SceneManager.LoadScene("_Scene_0");
    }
}

