using UnityEngine;
using System.Collections.Generic;

public class RuneManager : MonoBehaviour
{
    public RuneSet runeSet; //create a runeSet
    public string correctWord; //correct word to match
    public string craftingRune; //string to store the rune being crafted

    void Start()
    {
        runeSet = new RuneSet(correctWord); //create a new RuneSet with the correct word
    }

    void Update()
    {
        //check if the current rune matches the correct rune
        if (runeSet.CheckRune(craftingRune))
        {
            //if it matches, get a new random RuneSet
            runeSet = new RuneSet(correctWord);
            craftingRune = "";
        }
    }
}