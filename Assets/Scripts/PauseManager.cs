using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{ 
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
        }

        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        //freezes time
        Time.timeScale = 0;
        //pauses audio
        AudioListener.pause = true;
        //activates menu
        pauseMenuUI.SetActive(true);

        // unlocks cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);

        // lock cursor back

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
