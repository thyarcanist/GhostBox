using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNoises : MonoBehaviour
{
    public AudioSource NoiseMachine;
    public GameObject[] noisyGhosts;

    public AudioClip captureSound;
    public bool TriggerSound = true;

    // Start is called before the first frame update
    void Start()
    {
        NoiseMachine = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        noisyGhosts = GameObject.FindGameObjectsWithTag("Ghost");
        GetSpookyNoises();
    }

    public bool playSound = false;
    public void GetSpookyNoises()
    {
        if (TriggerSound && playSound)
        {
            NoiseMachine.PlayOneShot(captureSound);
            StartCoroutine(ResetValues());
        }
    }

    public void PlayCaptureSound()
    {
        StopCoroutine("ResetValues");
        playSound = true;
    }

    IEnumerator ResetValues()
    {
        yield return new WaitForSeconds(captureSound.length + .3f);
        playSound = false;
    }
}