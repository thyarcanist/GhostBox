using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryShifter : MonoBehaviour
{
    // Script that manages the story stuff;
    // Need to get working
    public GameObject gameManager;
    public Text sceneText;
    public readonly string[] scriptText01 = 
        {
        "One", 
        "Two",
        "Three",
        "Four"
        };

    // Start is called before the first frame update
    void Start()
    {
        GetObjREF();
        SwitchLines();
    }

    public void SwitchLines()
    {   // if SceneActive is Level_Story01 & ghost captures is 10 or more
        if ( SceneManager.GetActiveScene().name == "Level_Story01" && gameManager.GetComponent<GameManager>().ghostCounter <= 10)
        {
            // sets scene text to the index 1 in the array
            sceneText.text = scriptText01[1];
        }
    }

    private void GetObjREF()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
