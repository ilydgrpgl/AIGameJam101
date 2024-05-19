using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    public int numberShown;
    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed= true;
        numberShown= 0;
    }
    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }
    private IEnumerator RotateWheel() {
    coroutineAllowed= false;
        float initialanglex = transform.eulerAngles.x;
        for (int i=0; i<20;i++)
        {
            transform.Rotate(0f,3f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        
        coroutineAllowed= true;
        numberShown += 1;
        Debug.Log(gameObject.name+ " :"+numberShown);
        if (numberShown>5)
        {
            numberShown = 0;
        }
        Rotated(name, numberShown);
    }


}
