using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Rune Set", menuName = "Rune Set")]
public class RuneSet
{
    public string correctWord; //correct word
    public Rune[] runes; //array of runes

    public RuneSet(string correctWord)
    {
        this.correctWord = correctWord; //set the correct word
        SetRunes(); //create the runes
    }

    //create the runes
    public void SetRunes()
    {
        runes = new Rune[correctWord.Length]; //create an array of runes based on the length of the correct word
        //for each letter in the correct word
        for (int i = 0; i < correctWord.Length; i++)
        {
            //create a new rune
            Rune rune = ScriptableObject.CreateInstance<Rune>();
            rune.letter = correctWord[i].ToString(); //set the letter of the rune
            //add the rune to the array
            runes[i] = rune;
        }
    }

    //check if the current word matches the correct word
    public bool CheckRune(string craftingRune)
    {
        //if the lengths do not match, return false
        if (craftingRune.Length != correctWord.Length)
            return false;
        //check each letter in the crafting word
        for (int i = 0; i < craftingRune.Length; i++)
        {
            //if the letter does not match, return false
            if (craftingRune[i] != correctWord[i])
                return false;
        }
        //if all letters match, return true
        return true;
    }
}