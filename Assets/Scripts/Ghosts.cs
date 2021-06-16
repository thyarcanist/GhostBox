using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghosts : MonoBehaviour
{
    [Header("General Ghost Variables")]
    public GameObject Ghost;
    bool isClicked = false;
    bool hasTouched = false;
    public Image GhostSprite;
    public Sprite TouchedSprite;
    public Sprite ReturnSprite;

    public int GhostHealth = 25;
    private int DamageBy = 25;
    public float WaitToDelete = 3f;
    public bool didDie = false;


    [Header("Ghost Count")]
    // Ghost Count
    public GameObject GameManager;
    public GameObject[] ghosts;
    // Score Count
    public float GhostTimer = 0f;
    public float resetTimer = 0f;

    [Header("Removal of Magic Numbers to Adding")]
    public int nFastGrab = 5;
    public int nMidGrab = 3;
    public int nSlowGrab = 1;

    public int nTimeQuick = 2;
    public int nTimeSlow = 4;

    [Header("Range so thats its inbetween two")]
    public int nTimeMidR1 = 2;
    public int nTimeMidR2 = 3;

    [Header("Delete if not clicked")]
    public int nDeleteRange1 = 1;
    public int nDeleteRange2 = 10;
    public float _time;

    public int randDeleteTime;

    GhostHealthValues.GHValues Health;

    // Biggest Issue to Solve:
    // When you click, its not checking to see if the image is click. If anything is clicked it will happen. | SOLVED
    // New Issue: When It's Clicked, it still has 25 Health
    // New Issues: Counting is Off (ex.  click is 1, second is 3 and third is 7 | SOLVED

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        IdentifyGhost();
    }

    // Time until Deletion of GameObject (Without Pressing)
    void Awake()   
    {
        randDeleteTime = (int)Random.Range(nDeleteRange1, nDeleteRange2);
        _time = randDeleteTime;
    }



    // Update is called once per frame
    void Update()
    {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        GhostTimer = GhostTimer + Time.deltaTime;
        // this is not going down, _time
        _time -= Time.deltaTime;

        transform.Rotate(1, 0, 1);

        CheckToCapture();
        PointGiver();
        Delete();
    }

    private void Delete()
    {
        if (_time <= 0)
        {
            Destroy(gameObject);
        }
    }

    // < Less Than and > Greater Than

    public void PointGiver() // gives points for clicking in time
    {
        if (Ghost.activeInHierarchy == false && GhostTimer <= nTimeQuick)
        {
            // Give Five Points
            GameManager.GetComponent<GameManager>().AddPoints(nFastGrab);
            GhostTimer = resetTimer;
        }
        else if (Ghost.activeInHierarchy == false && GhostTimer <= nTimeMidR1 && GhostTimer > nTimeMidR2)
        {
            // Give Three Points
            GameManager.GetComponent<GameManager>().AddPoints(nMidGrab);
            GhostTimer = resetTimer;
        }
        else if (Ghost.activeInHierarchy == false && GhostTimer >= nTimeSlow)
        {
            // Give One Point
            GameManager.GetComponent<GameManager>().AddPoints(nSlowGrab);
            GhostTimer = resetTimer;
        }
    }

    // Allows Player To Click On And Do It
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.tag == "Ghost")
        {
            OnPress();

            if (GhostHealth <= 0)
            {
                BagIt();
            }
        }
    }

    public void CheckToCapture()
    {
        if (GhostHealth <= 0)
        {
            BagIt();
            return;
        }
    }

    public void GhostPresses()
    {

        if (Input.GetMouseButtonDown(0) && gameObject.tag == "Ghost")
        {
            OnPress();

            if (GhostHealth <= 0)
            {
                BagIt();
            }

            return;
        }
        return;
    }
    
    // Allows It To Be Pressed
    public void OnPress()
    {
            hasTouched = true;
            GhostSprite.sprite = TouchedSprite;
            GhostHealth = GhostHealth - DamageBy;
            Debug.Log("You have clicked me.");
    }

    public void BagIt()
    {
        GameManager.GetComponent<GameManager>().CaptureGhost();
        hasTouched = false;
        didDie = true;
        StartCoroutine(DeleteSprite());
        Debug.Log("Ghost is destroyed.");

    }

    IEnumerator DeleteSprite()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(WaitToDelete);
        Destroy(Ghost);
    }
    
    private void IdentifyGhost()
    {
        Ghost = GameObject.FindGameObjectWithTag("Ghost");
    }
}


#region DEPRICATED

//public void OnPress()
//{
//    if (Input.GetKeyDown(KeyCode.Mouse0) && gameObject.tag == "Ghost")
//    {
//        hasTouched = true;
//        GhostSprite.sprite = TouchedSprite;
//        GhostHealth = GhostHealth - DamageBy;
//        Debug.Log("You have clicked me.");
//        return;
//    }
//}


#endregion