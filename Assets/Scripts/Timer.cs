using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0) {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0) {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int secondes = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
