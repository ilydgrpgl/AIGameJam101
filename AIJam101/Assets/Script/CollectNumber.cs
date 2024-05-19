using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectNumber : MonoBehaviour
{
    public GameObject pressE;
    [SerializeField]public Sprite insideNumber;

    private void Start()
    {
        pressE.SetActive(false);
    }

}
