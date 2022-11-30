using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] float timeToAnswerQuestion;
    [SerializeField] float timeToShowAnswer;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    public float fillFraction;

    float timerValue;
    float currentTimerInterval;


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();   
    }

    public void CancelTimer() 
    {
        timerValue = 0;
    }

    void UpdateTimer() 
    {
        timerValue -= Time.deltaTime;

        if (timerValue > 0) 
        {
            fillFraction = timerValue / currentTimerInterval;
        }

        if (timerValue <= 0 && isAnsweringQuestion)
        {
            isAnsweringQuestion = false;

            currentTimerInterval = timerValue = timeToShowAnswer;
        }
        else if (timerValue <= 0) 
        {
            isAnsweringQuestion = true;

            loadNextQuestion = true;

            currentTimerInterval = timerValue = timeToAnswerQuestion;
        }
    }
}
