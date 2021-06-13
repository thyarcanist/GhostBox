using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghosts : MonoBehaviour
{
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



    // Ghost Count
    public GameObject GameManager;
    public GameObject[] ghosts;
    // Score Count
    public float GhostTimer = 0f;
    public float resetTimer = 0f;

    GhostHealthValues.GHValues Health;

    // Biggest Issue to Solve:
    // When you click, its not checking to see if the image is click. If anything is clicked it will happen.
    // New Issue: When It's Clicked, it still has 25 Health
    // New Issues: Counting is Off (ex. first click is 1, second is 3 and third is 7

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        IdentifyGhost();
    }

 

    // Update is called once per frame
    void Update()
    {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        CheckToCapture();
        GhostTimer = GhostTimer + Time.deltaTime;
        PointGiver();

    }

    // < Less Than and > Greater Than
    public void PointGiver()
    {
        if (Ghost.activeInHierarchy == false && GhostTimer <= 2)
        {
            // Give Five Points
            GameManager.GetComponent<GameManager>().AddPoints(5);
            GhostTimer = resetTimer;
            return;
        }
        else if (Ghost.activeInHierarchy == false && GhostTimer <= 2 && GhostTimer > 3)
        {
            // Give Three Points
            GameManager.GetComponent<GameManager>().AddPoints(3);
            GhostTimer = resetTimer;
            return;
        }
        else if (Ghost.activeInHierarchy == false && GhostTimer >= 4)
        {
            // Give One Point
            GameManager.GetComponent<GameManager>().AddPoints(1);
            GhostTimer = resetTimer;
            return;
        }
        return;
    }

    // Allows Player To Click On And Do It
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && this.gameObject.tag == "Ghost")
        {
            OnPress();

            if (GhostHealth <= 0)
            {
                BagIt();
            }

            return;
        }
    }

    public void CheckToCapture()
    {
        if (GhostHealth <= 0)
        {
            BagIt();
            return;
        }

        return;
    }

    public void GhostPresses()
    {

        if (Input.GetMouseButtonDown(0) && this.gameObject.tag == "Ghost")
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
            return;
    }

    public void BagIt()
    {
        GameManager.GetComponent<GameManager>().CaptureGhost();
        hasTouched = false;
        didDie = true;
        StartCoroutine(DeleteSprite());
        Debug.Log("Ghost is destroyed.");
        return;

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
        return;
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