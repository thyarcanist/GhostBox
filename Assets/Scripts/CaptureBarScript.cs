using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureBarScript : MonoBehaviour
{
    private Slider ghostSlider;
    public GameObject GameManager;

    public float nCaptures = 0;
    public float fFillSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ghostSlider = gameObject.GetComponent<Slider>();

        SetCaptureMaxValue();
    }

    // Update is called once per frame
    void Update()
    {
        SetCaptureMaxValue();

        // fills progress bar
        if (ghostSlider.value < ghostSlider.maxValue) { ghostSlider.value += fFillSpeed * Time.deltaTime; }
    }

    public void ShowProgress(float currentProgress)
    {
        // adds number of captures to ghostSlider
        // I know why, going to fix soon
        nCaptures = ghostSlider.value + currentProgress;
    }

    // Show Capture Percentage
    private void SetCaptureMaxValue()
    {
        // set these values to correlate with ghosts
        ghostSlider.maxValue = GameManager.GetComponent<GameManager>().nGhostNumbers;

    }
}
