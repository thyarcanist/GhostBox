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

    public int nGhostSpawnStopNum;
    public int _ghostNumbers; // temp

    // Ghost Randomizer
    public GameObject[] ghostTypes;
    public int randomGhost;
    public bool bSpawnGhosts = true;

    public float deployFloat = 5.0f;

    [Header("Reference to GameManager Script")]
    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        deployTime = deployFloat;

        // sets the boundaries of the game
        gameBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        StartCoroutine(ghostWaves());
    }

    public void Update()
    {
        _ghostNumbers = GameManager.GetComponent<GameManager>().nGhostNumbers;
        Randomizers();
    }


    private void Randomizers()
    {
        // should randomize the spawn time with each update
        randDeploy = Mathf.Round(Random.Range(5f, 10f));

        // randomize the spawn time for ghosts after intial spawn
        deployTime = Mathf.Round(Random.Range(1.5f, 5f));

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
            GameManager.GetComponent<GameManager>().nGhostNumbers = _ghostNumbers += 1;
            SpawnEntity();
        }
    }
}