using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    // The Meat and Potatos of this, this is what spawns the ghosts in the game. 
    // Need to Create the Prefabs to be instantiated

    public Transform parentGhost; // initial ghost
    public GameObject ghostPrefab;
    public float deployTime;
    public float randDeploy;
    private Vector2 gameBoundaries;

    public int nGhostNumbers;
    public int nGhostSpawnStopNum;

    // Ghost Randomizer
    public GameObject[] ghostTypes;
    public int randomGhost;
    public bool bSpawnGhosts = true;

    public float deployFloat = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        deployTime = deployFloat;

        // sets the boundaries of the game
        gameBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ghostWaves());
    }

    public void Update()
    {
        Randomizers();

        if (nGhostNumbers <= nGhostSpawnStopNum)
        {
            // stop spawning ghosts
            bSpawnGhosts = false;
        }
    }

    private void Randomizers()
    {
        // should randomize the spawn time with each update
        randDeploy = Random.Range(5f, 10f);

        // randomizes the ghost
        randomGhost = Random.Range(0, ghostTypes.Length);
    }

    private void SpawnEntity()
    {
        GameObject ghostType01 = Instantiate(ghostTypes[randomGhost], parentGhost);
        ghostType01.transform.SetParent(parentGhost.transform); // spawns it very large and in the wrong area
    }

    IEnumerator ghostWaves()
    {
        while (bSpawnGhosts == true)
        {
            yield return new WaitForSeconds(deployFloat); // normally deployFloat
            nGhostNumbers = nGhostNumbers += 1;
            SpawnEntity();
        }
    }
}