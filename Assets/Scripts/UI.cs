using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject gameOverPanel;

    private int cevap;
    private float timer = 60f;
    private int score = 0;
    private bool isGameOver;


    public Text timerText;
    public Text scoreText;
    public Text questionText;

    public Button answerButton1;
    public Button answerButton2;
    public Button answerButton3;
    public Button answerButton4;

    void Start()
    {
        NewQuestion();
        MyData.questionData = QuestionReceived;
    }

    private void QuestionReceived(QuestionData a)
    {
        questionText.text = a.Question;
        answerButton1.GetComponentInChildren<Text>().text = a.A;
        answerButton2.GetComponentInChildren<Text>().text = a.B;
        answerButton3.GetComponentInChildren<Text>().text = a.C;
        answerButton4.GetComponentInChildren<Text>().text = a.D;
        cevap = a.CevapId;
    }

    void NewQuestion()
    {
        FindObjectOfType<MyData>().GetDataJson();
    }
    
    public void ReturnTheButtonIndex(int le)
    {
        if (le == cevap)
        {
            NewQuestion();
            score += 5;
        }
        else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        questionPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void TextUpdate()
    {
        if (isGameOver)
        {

        }
        else
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timer).ToString();
            scoreText.text = "Score: " + score;
        }
        
    }

    void Update()
    {
        TextUpdate();
    }
}
