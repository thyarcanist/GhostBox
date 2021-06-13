using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class AudioFixer : MonoBehaviour
{

    public AudioSource BackgroundAudio;
    public bool SoundOn;
    public Image AudioSprite;
    public Sprite AudioOn;
    public Sprite AudioOff;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //// Handles Screen Touch
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    ToggleAudio();
        //    return;
        //}

        RunAudioChecks();

    }

    public void RunAudioChecks()
    {
        SpriteSwap();
        GetSoundCheck();
        return;
    }

    private void SpriteSwap()
    {
        if (SoundOn == true)
        {
            AudioSprite.sprite = AudioOn;
            return;
        }
        else if (SoundOn == false)
        {
            AudioSprite.sprite = AudioOff;
            return;
        }
        return;
    }

    private void GetSoundCheck()
    {
        if (BackgroundAudio.enabled == true)
        {
            SoundOn = true;
            return;
        }
        else
        {
            SoundOn = false;
            return;
        }
    }

    private void GetAudioSprites()
    {

    }

    public void ToggleAudio()
    {
        BackgroundAudio.enabled = !BackgroundAudio.enabled;
        return;
    }
}
