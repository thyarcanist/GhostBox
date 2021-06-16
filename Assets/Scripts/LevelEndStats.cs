using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndStats : MonoBehaviour
{
    // OBJ: Create a script that pops up at the end of the level, but before the level transitions to the next scene, the player will need to click to go to the next scene.

    public Text winText;
    public Text ratioText;

    public GameObject GameManager;
    public GameObject endLevelUI;

    private void Start()
    {
        GetObJREF();
    }



    void GetObJREF()
    {
        // Gets GameManger Object
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        endLevelUI = GameObject.FindGameObjectWithTag("EndLevelUI");
    }
}
