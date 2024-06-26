using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    private float timeValue = 180f;

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

    }

    private void DisplayTime(float timeValueToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeValueToDisplay / 60f);
        float seconds = Mathf.FloorToInt(timeValueToDisplay % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
