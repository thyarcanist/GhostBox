using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [Header("Time Logic")]
    public float fTimeCounter;
    public float fMaxTime = 60;
    public double nTimeConvert;

    [Header("Time UI")]
    public Text TimeText;

    [Header("When Timer is zero go to next Scene")]
    public string sNextScene;

    void Start()
    {
        // start level with fTimeCounter set to fMaxTime
        fTimeCounter = fMaxTime;
    }

    void Update()
    {
        VariableClamps();
        CountdownTimer();
        CountdownLogic();
    }

    public float CountdownTimer()
    {
       return fTimeCounter = fTimeCounter -= Time.deltaTime;
    }

    public void CountdownLogic()
    {
        // converts float TimeCounter into a double and rounds it to zero
        nTimeConvert = System.Math.Round(fTimeCounter, 0);
        // displays the converted TimeConvert
        TimeText.text = nTimeConvert.ToString();

        if (fTimeCounter <= 0)
        {
            SceneManager.LoadScene(sNextScene);
        }
    }


    private void VariableClamps()
    {
        Mathf.Clamp(fTimeCounter, 0, fMaxTime);
    }
}
