using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNoises : MonoBehaviour
{
    public AudioSource NoiseMachine;
    public GameObject[] noisyGhosts;

    public AudioClip captureSound;

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

    public void GetSpookyNoises()
    {
        for (int i = 0; i < noisyGhosts.Length; i++)
        {
            if (noisyGhosts[i].GetComponent<Ghosts>().didDie == true)
            {
                NoiseMachine.PlayOneShot(captureSound);
                Destroy(gameObject);
            }
        }
    }
}


#region DEPRICATED

//public void GetSpookyNoises()
//{
//    if (gameObject.tag == "Ghost")
//    {
//        for (int i = 0; i < noisyGhosts.Length; i++)
//        {
//            if (noisyGhosts[i].GetComponent<Ghosts>().isDead == true)
//            {
//                NoiseMachine.PlayOneShot(captureSound);
//            }
//        }
//    }
//}


#endregion