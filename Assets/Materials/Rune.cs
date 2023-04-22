using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rune", menuName = "Rune")]
//Rune
public class Rune : ScriptableObject
{
    public string letter; //letter associated with the rune
    public Sprite sprite; //sprite associated with the rune
}