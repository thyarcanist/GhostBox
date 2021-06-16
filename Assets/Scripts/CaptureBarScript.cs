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
    }

    // Update is called once per frame
    void Update()
    {
        // fills progress bar
        if (ghostSlider.value < ghostSlider.maxValue) { ghostSlider.value += fFillSpeed * Time.deltaTime; }
    }

    public void ShowProgress(float currentProgress)
    {
        // adds number of captures to ghostSlider
        // I know why, going to fix soon
        ghostSlider.value = currentProgress;
    }

}
