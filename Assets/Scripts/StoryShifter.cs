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
        "All Ghosts Captured\n\n 'You got them all!",
        "You have captured more than 75% of the ghosts\n\n Keep doing well!",
        "75% of ghosts captured.\n\n 'Hey your pretty good'",
        "50% of ghosts captued.\n\n",
        "35% of ghosts captued.\n\n",
        "No Ghosts Captured.\n\n What were you doin'?"
        };

    // Start is called before the first frame update
    void Start()
    {
        GetObjREF();
        SwitchScript();
    }

    private void SwitchScript()
    {
        if (gameManager.GetComponent<GameManager>()._dGhostPer >= 1f)
        {
            sceneText.text = scriptText01[0];
            Debug.Log("All Ghosts Captured");
            Debug.Log("Pass");
        }
        else if (gameManager.GetComponent<GameManager>()._dGhostPer >= 0.75f)
        {
            sceneText.text = scriptText01[1];
            Debug.Log("You have captued more than 75% of the ghosts.");
            Debug.Log("Pass");
        }
        else if (gameManager.GetComponent<GameManager>()._dGhostPer <= 0.75f)
        {
            sceneText.text = scriptText01[2];
            Debug.Log("75% of ghosts captured.");
            Debug.Log("Pass");
        }
        else if (gameManager.GetComponent<GameManager>()._dGhostPer <= 0.5f)
        {
            sceneText.text = scriptText01[3];
            Debug.Log("50% of ghosts captued.");
            Debug.Log("Fail");
        }
        else if (gameManager.GetComponent<GameManager>()._dGhostPer <= 0.35f)
        {
            sceneText.text = scriptText01[4];
            Debug.Log("35% of ghosts captued.");
            Debug.Log("Fail");
        }
        else
        {
            sceneText.text = scriptText01[5];
            Debug.Log("Ghost Percentage change");
            Debug.Log("Error in SwitchScript");
        }
    }

    private void GetObjREF()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
}
