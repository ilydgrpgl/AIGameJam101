using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    private int[] result, correctCombination;

    // Start is called before the first frame update
    void Start()
    {
        result = new int[] { 5, 5, 5 };
        correctCombination = new int[] { 2, 5, 3 };
        Rotate.Rotated += CheckResults;
    }
    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "whell1":
                result[0] = number;
                break;
            case "whell2":
                result[1] = number;
                break;
            case "whell3":
                result[2] = number;
                break;
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            Debug.Log("opened");
        }
    }
    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
    
}
