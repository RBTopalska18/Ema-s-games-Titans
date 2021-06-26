using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class math : MonoBehaviour
{
    public Text wordOutput;
    public Text scoreText;
    public InputField inputfield;
    string container;

    private int numberA;
    private int numberB;
    private int sign;
    private int score = 0;
    private int wholeNumber;


    private void Start()
    {
        scoreText.text = score.ToString();
        chooseNumbers();
        Debug.Log(sign);

        getAnswer();
    }

    void Update()
    {
        if (sign == 0)
        {
            wholeNumber = numberB + numberA;
        }
        else if (sign == 1)
        {
            if (numberA < numberB)
            {
                wholeNumber = numberB - numberA;
            }
            else
            {
                wholeNumber = numberA - numberB;
            }
        }
        else
        {
            wholeNumber = numberB * numberA;
        }
        if (container == wholeNumber.ToString() && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<AudioManager>().Play("right");
            clear();
            score++;
            scoreText.text = score.ToString();
            chooseNumbers();
            getAnswer();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<AudioManager>().Play("wrong");
            score = 0;
            scoreText.text = score.ToString();
            clear();
            getAnswer();
        }
    }

    private void chooseNumbers()
    {
        numberA = Random.Range(0, 11);
        numberB = Random.Range(0, 11);
        sign = Random.Range(0, 3);
        if (sign == 0)
        {
            wordOutput.text = numberA.ToString() + " + " + numberB.ToString();
        }
        else if (sign == 1)
        {
            if (numberA < numberB)
            {
                wordOutput.text = numberB.ToString() + " - " + numberA.ToString();
            }
            else
            {
                wordOutput.text = numberA.ToString() + " - " + numberB.ToString();
            }
        }
        else
        {
            wordOutput.text = numberA.ToString() + " x " + numberB.ToString();
        }
    }

    private void clear()
    {
        inputfield.Select();
        inputfield.text = "";
    }

    public void getAnswer()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitAnswer);
        input.onEndEdit = se;
    }

    private void SubmitAnswer(string text)
    {
        container = text;
    }
}
