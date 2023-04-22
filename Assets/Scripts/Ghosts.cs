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



    public int ghostHealth = 25;
    private int DamageBy = 25;
    public float WaitToDelete = 3f;
    public bool didDie = false;


    [Header("Ghost Count")]
    // Ghost Count
    public GameObject GameManager;
    public GameObject NoiseGen;
    public GameObject[] ghosts;
    // Score Count
    public float GhostTimer = 0f;
    public float resetTimer = 0f;

    [Header("Removal of Magic Numbers to Adding")]
    public float nFastGrab = 6;
    public float nMidGrab = 3;
    public float nSlowGrab = 1;

    public float nTimeQuick = 0.5f;
    public float nTimeSlow = 1.7f;

    [Header("Range so thats its inbetween two")]
    public float nTimeMidR1 = .6f;
    public float nTimeMidR2 = 1.6f;

    [Header("Delete if not clicked")]
    public int nDeleteRange1 = 1;
    public int nDeleteRange2 = 10;
    public float _time;

    public int randDeleteTime;

    GhostHealthValues.GHValues Health;

    [Header("Wisp Attributes")]
    public bool isTypeWisp = false;

    // Biggest Issue to Solve:
    // When you click, its not checking to see if the image is click. If anything is clicked it will happen. | SOLVED
    // New Issue: When It's Clicked, it still has 25 Health
    // New Issues: Counting is Off (ex.  click is 1, second is 3 and third is 7 | SOLVED
    // New Issue: Continous points earned whenever, try new logic.

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        NoiseGen = GameObject.FindGameObjectWithTag("NoiseManager");
        IdentifyGhost();
        if (isTypeWisp)
        {
            ghostHealth = ghostHealth + 50;
        }
    }

    // Time until Deletion of GameObject (Without Pressing)
    void Awake()   
    {
        randDeleteTime = (int)Random.Range(nDeleteRange1, nDeleteRange2);
        _time = randDeleteTime;
        Ghost = gameObject;
    }



    // Update is called once per frame
    void Update()
    {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        GhostTimer += GhostTimer + Time.deltaTime;
        // this is not going down, _time
        _time -= Time.deltaTime;

        transform.Rotate(0, .2f, 1);

        CheckToCapture();
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
        if (!didDie)
        {
            Debug.Log("PointGiver function accessed");
            if (GhostTimer <= nTimeQuick) // GhostTimer is less than or equal to nTimeQuick
            {
                // Give Five Points
                GameManager.GetComponent<GameManager>().AddPoints((int)nFastGrab);
                GhostTimer = resetTimer;
                Debug.Log($"GhostTimer is at {GhostTimer}, \n _time is at {_time}");
            }
            else if (GhostTimer > nTimeMidR1 && GhostTimer > nTimeMidR2) // GhostTimer is less than nTimeMidR1 and GhostTimer is greater than nTimeMidR2
            {
                // Give Three Points
                GameManager.GetComponent<GameManager>().AddPoints((int)nMidGrab);
                GhostTimer = resetTimer;
                Debug.Log(nMidGrab);
                Debug.Log($"GhostTimer is at {GhostTimer}, \n _time is at {_time}");
            }
            else if (GhostTimer > nTimeSlow) // GhostTimer is greater than or equal to nTimeSlow
            {
                // Give One Point
                GameManager.GetComponent<GameManager>().AddPoints((int)nSlowGrab);
                GhostTimer = resetTimer;
                Debug.Log(nSlowGrab);
                Debug.Log($"GhostTimer is at {GhostTimer}, \n _time is at {_time}");
            }
            didDie = true;
        }
    }

    // Allows Player To Click On And Do It
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.tag == "Ghost")
        {
            OnPress();

            if (ghostHealth <= 0)
            {
                BagIt();
            }
        }
    }

    public void CheckToCapture()
    {
        if (ghostHealth <= 0)
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

            if (ghostHealth <= 0)
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
            NoiseGen.GetComponent<GhostNoises>().PlayCaptureSound();
            hasTouched = true;
            GhostSprite.sprite = TouchedSprite;
            ghostHealth = ghostHealth - DamageBy;
            Debug.Log("You have clicked me.");
    }

    public void BagIt()
    {
        PointGiver();
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