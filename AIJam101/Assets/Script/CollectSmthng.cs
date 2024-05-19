using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectSmthng : MonoBehaviour
{
    private GameObject currentGO;
    public GameObject numbersPanel;
    [SerializeField] Image[] numberImages;

    private void Start()
    {
        numbersPanel.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && currentGO != null)
        {
            Debug.Log(currentGO.name + " toplandý.");
            numbersPanel.SetActive(true);
            for(int i = 0; i<3; i++)
            {
                Debug.Log(numberImages[i].sprite);
                if (numberImages[i].sprite == null)
                {
                    numberImages[i].sprite = currentGO.GetComponent<CollectNumber>().insideNumber;
                    Destroy(currentGO);
                    break;
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collectable"))
        {
            currentGO = other.gameObject;
            currentGO.GetComponent<CollectNumber>().pressE.SetActive(true);
        }else if (other.transform.CompareTag("Finish"))
        {
            SceneManager.LoadScene("GecmisBulmaca");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Collectable"))
        {
            currentGO.GetComponent<CollectNumber>().pressE.SetActive(false);
            currentGO = null;
        }
    }
}
