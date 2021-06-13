using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxLogic : MonoBehaviour
{
    [Header("Box Logic Variables")]
    public Sprite BoxClosed;
    public Sprite BoxOpen;
    public Image ImageBox_Panel;

    public bool bIsGhostOut = false;

    [Header("Variables for GhostManager")]
    public GameObject GhostManager;
    private int ghostLength;

    // Start is called before the first frame update
    void Start()
    {
        GetObjectReference();
    }

    // Update is called once per frame
    void Update()
    {
        ghostLength = GhostManager.GetComponent<GhostSpawner>().ghostTypes.Length;

        CheckGhostsOnScene();
        BoxSwitch();
    }

    void GetObjectReference()
    {
        ImageBox_Panel = GameObject.FindGameObjectWithTag("Box").GetComponent<Image>();
        GhostManager = GameObject.FindGameObjectWithTag("GhostManager");
    }

    void BoxSwitch()
    {
        if (bIsGhostOut)
        {
            ImageBox_Panel.sprite = BoxOpen;
        }
        else
        {
            ImageBox_Panel.sprite = BoxClosed;
        }
    }

    void CheckGhostsOnScene()
    {
        // if ghosts are active in the scene set bIsGhostOut is true or set to false

        if (ghostLength >= 1)
        {
            bIsGhostOut = true;
        }
        else if (ghostLength <= 0)
        {
            bIsGhostOut = false;
        }
        else { Debug.Log("Error range in CheckGhostsOnScene"); }
    }
}
