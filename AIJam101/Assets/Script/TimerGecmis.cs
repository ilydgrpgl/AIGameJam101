using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerGecmis : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] Slider timerSlider;
    [SerializeField] public float decSpeed=1;

    private void Start()
    {
        timerSlider.maxValue = remainingTime;
    }
    private void Update()
    {
        timerSlider.value = remainingTime;
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime * decSpeed;
            if(remainingTime<=10)
            {
                timerText.color= Color.red;
            }
        }
        
        else if (remainingTime < 0)
        {
            remainingTime= 0;
            Debug.Log("Oyun Bitti");
        }
       
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds= Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);



    }
    public void PauseGame()
    {

        decSpeed = 0;
    }
    public void ContGame()
    {

        decSpeed = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("TimeSlower"))
        {
            decSpeed = 0.5f;
            Debug.Log("Zaman yavaþladý");
            StartCoroutine(ResetSlower(10));
            Destroy(other.gameObject);
        }
    }

    IEnumerator ResetSlower(float doTime)
    {
        float time = 0;
        while (time < doTime) 
        {
            time += Time.deltaTime;
            yield return null;
        }
        decSpeed = 1;

    }
}
