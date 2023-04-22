using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode : MonoBehaviour
{
    string j = "racecar";
    string t = "hello";
    string m = "mountain";
    string c = "civic";

    int nA = 515;
    int nB = 78178;
    int nC = 9021209;
    int nD = 72611;

    private void Start()
    {
        Debug.Log(PalindromeCheck(t));
        Debug.Log(PalindromeIntCheck(nB));
    }

    public bool PalindromeCheck(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
    public bool PalindromeIntCheck(int x)
    {
        string r = x.ToString();

        int left = 0;
        int right = r.Length - 1;

        while (left < right)
        {
            if (r[left] != r[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

}
