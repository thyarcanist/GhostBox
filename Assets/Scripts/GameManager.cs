using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Standard

    [Header("Score and Ghost Captures")]
    public int pointCounter;
    public int ghostCounter;

    // stats to look at 
    private int totalGhostsCaptured;
    private float totalCapturePercentage;

    public Text counterText;
    public Text pointText;

    [Header("Ghost Measuring Bar")]
    // gets the percentage based on ghostCounter / nMaxGhostCap
    public float dGhostPer;
    public int nGhostNumbers; // the first ghost that isn't spawned
    public GameObject CaptureBarUI;
    private string directoryImage = "CaptureBar";

    // hold variables, for storyshifter script and then reset
    public float _dGhostPer;
    public int _nGhostsFound;
    public int _ghostsCaptured;
    public int _pointCounter;

    public bool bAtLevelEnd = false; // timer reached zero
    public bool bNextLevel = false; // to transition to next level

    public bool bHasReachedEndL = false; // ?

    #endregion
    #region Special
    [SerializeField]
    public int playAgain;
    bool givePlayPoint;
    // Need to fix play again & give points they just infinitely loop

    void CallItOnce(bool didPlayAgain)
    {
        if (didPlayAgain)
        {
            givePlayPoint = true;
            if (givePlayPoint)
            {
                StartCoroutine(DeliverThePoint());
                givePlayPoint = false;
            }
        }
    }

    #endregion
    private void Start()
    {
        // the first ghost that isn't spawned
        nGhostNumbers = 1;
        GetObjectReference();
    }

    public bool setToLandscape = false;
    public  void SetScreenOrientation()
    {
        if (setToLandscape)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    private List<(float, int, int, int)> perGameSession = new List<(float, int, int, int)>();
    private List<(float, int, int, int)> entireTotal = new List<(float, int, int, int)>();

    public void SaveValues()
    {
        perGameSession.Add((_dGhostPer, _nGhostsFound, _ghostsCaptured, _pointCounter));
        entireTotal.Add((_dGhostPer, _nGhostsFound, _ghostsCaptured, _pointCounter));
    }

    public void EraseValues()
    {
        perGameSession.Clear();
    }

    public void SaveProfile(int playerID)
    {
        using (StreamWriter writer = new StreamWriter("playerProfile_" + playerID + ".txt"))
        {
            writer.WriteLine(playerID);
            writer.WriteLine(entireTotal.Count);
            foreach (var entry in entireTotal)
            {
                writer.WriteLine(entry.Item1 + " " + entry.Item2 + " " + entry.Item3 + " " + entry.Item4);
            }
        }
    }

    public void CaptureGhost()
    {
        ghostCounter++;
    }

    public void AddPoints(int pointAdd)
    {
        pointCounter += pointAdd;
    }

    private void CaptureLevelPercentageAndShow()
    {
        dGhostPer = (float)ghostCounter / (float)nGhostNumbers;
        CaptureBarUI.GetComponent<CaptureBarScript>().ShowProgress(dGhostPer);

        GhostCaptureCount();
    }

    public void GhostCaptureCount()
    {
        counterText.text = ghostCounter.ToString();
        pointText.text = pointCounter.ToString();
    }

    public void HoldValues()
    {
        // Holds Values for StoryShifter script

        _dGhostPer = dGhostPer; // Percentage
        _nGhostsFound = nGhostNumbers; // Ghost Numbers
        _ghostsCaptured = ghostCounter; // ghost captured
        _pointCounter = pointCounter; // Score
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Spirit01")
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "Level_Story01")
        {
            DontDestroyOnLoad(gameObject);
            CallItOnce(true);
        }
        // updates totalGhostsCaptured to meet the number of ghosts
        totalGhostsCaptured = ghostCounter;

        CaptureLevelPercentageAndShow();
        ComboChainCounter();
    }

    public Text multiPlierCombo;
    public Text multiPlierSum;
    public bool ComboSuccessful;
    public bool ComboStart;
    public GameObject ComboDisplay;

    private void DisplayCombo()
    {
        if (ComboStart)
        {
            ComboDisplay.SetActive(true);
            multiPlierCombo.text = "Combo x" + comboModifier;
            multiPlierSum.text = "Sum: " + (points * comboModifier);
        }
        else
        {
            ComboDisplay.SetActive(false);
        }
    }

    public void AddMultiPoints(int points)
    {
        if (ComboSuccessful)
        {
            pointCounter += (int)(points * comboModifier);
        }
        else
        {
            pointCounter += (int)(points * comboModifier * 0.25f);
        }

        ResetCombo();
    }

    private void ResetCombo()
    {
        comboModifier = 1f;
        multiPlierCombo.text = "";
        multiPlierSum.text = "";
    }

    private float comboModifier = 1f;
    private int consecutiveCaptures = 0;
    private float scorePerHit;
    private int points;

    private void ComboChainCounter()
    {
        consecutiveCaptures++;
        switch (consecutiveCaptures)
        {
            case 3:
                comboModifier = 0.5f;
                break;
            case 6:
                comboModifier = 1.5f;
                break;
            case 9:
                comboModifier = 2f;
                break;
            case 12:
                comboModifier = 2.5f;
                break;
            default:
                break;
        }

        if (consecutiveCaptures % 3 == 0)
        {
            consecutiveCaptures = 0;
        }
    }

    private void GetObjectReference()
    {
        CaptureBarUI = GameObject.FindGameObjectWithTag(directoryImage);
    }


    // Buttons

    #region GameButtons
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueButton() // Continues to Next Scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion

    IEnumerator DeliverThePoint()
    {
        yield return new WaitForSeconds(1);
        playAgain++;
        givePlayPoint = false;
    }
}


