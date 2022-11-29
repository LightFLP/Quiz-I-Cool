using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;


    void Start()
    {
        correctAnswerIndex = questionSO.GetCorrectAnswerIndex();
        GetNextQuestion();
    }

    void DisplayQuestionAndAnswers()
    {
        questionText.text = questionSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSO.GetAnswer(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetNextQuestion() 
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestionAndAnswers();
    }

    public void OnAnswerSelected(int index) 
    {
        Image buttonImage;

        if (index == questionSO.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
        }
        else 
        {
            questionText.text = "Incorrect! \n The correct answer is:";
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        }

        buttonImage.sprite = correctAnswerSprite;
        SetButtonState(false);
    }

    void SetButtonState(bool state) 
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites() 
    {
        Image buttonImage;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
