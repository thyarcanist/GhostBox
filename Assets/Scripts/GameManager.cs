using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int pointCounter = 0;
    public int ghostCounter = 0;
    public Text counterText;
    public Text pointText;

    [Header("Ghost Measuring Bar")]
    public int nMaxGhostCap; // MaxGhostCap for level progression
    // gets the percentage based on ghostCounter / nMaxGhostCap
    public double dGhostPer;

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
        dGhostPer = ghostCounter / nMaxGhostCap;
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
            DontDestroyOnLoad(this.gameObject);
            GhostCaptureCount();
        }

        //ComboChainCounter();
    }

    private void ComboChainCounter()
    {
       // Script Combo Here
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


