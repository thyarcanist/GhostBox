using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    private void Start()
    {
        // the first ghost that isn't spawned
        nGhostNumbers = 1;
        GetObjectReference();
    }

    public void CaptureGhost()
    {
        ghostCounter = ghostCounter + 1;
    }

    public void AddPoints(int pointAdd)
    {
        pointCounter = pointCounter + pointAdd;
    }

    private void CaptureLevelPercentageAndShow()
    {
        dGhostPer =  (float)ghostCounter / (float)nGhostNumbers;
        CaptureBarUI.GetComponent<CaptureBarScript>().ShowProgress(dGhostPer);
    }

    public void GhostCaptureCount()
    {
        counterText.text = ghostCounter.ToString();
        pointText.text = pointCounter.ToString();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level_01")
        {
            DontDestroyOnLoad(gameObject);
            GhostCaptureCount();
        }
        // updates totalGhostsCaptured to meet the number of ghosts
        totalGhostsCaptured = ghostCounter;

        CaptureLevelPercentageAndShow();
        //ComboChainCounter();
    }

    private void ComboChainCounter()
    {
       // Script Combo Here
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
}


