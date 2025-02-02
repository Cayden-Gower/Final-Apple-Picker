using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -16f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList; //creates a list of baskets

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) { //instantiate 4 baskets
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
            Debug.Log($"Creating basket {i + 1} at position {pos.y}\n");
        }
        Debug.Log($"Total baskets created: {basketList.Count}\n");
    }
    public void AppleMissed() {
        //Destroy all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple"); //creates array of gameobjects w/ apple tag
        foreach ( GameObject tempGO in appleArray) { //deletes all objects in that array
            Destroy(tempGO);
        }

        //Destroy one of the baskets
        //Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        //Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        //Remove the basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy (basketGO);

        //If no more baskets left, restart game
        if ( basketList.Count == 0 ) {
            SceneManager.LoadScene("_Game_Over" );
        }
    }

    public void BranchMissed() {
        GameObject[] branchArray = GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject tempGO in branchArray) {
            Destroy(tempGO);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
