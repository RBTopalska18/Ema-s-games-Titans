using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class geography : MonoBehaviour
{
    public Text wordOutput;
    public Text scoreText;
    private string container;
    public InputField inputfieldname;

    private string[] Country = { "Bulgaria", "Turkey", "Germany", "France" };
    private string[] Capital = { "София", "Истамбул", "Берлин", "Париж" };
    private int randomIndex;
    private int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
        randomIndex = Random.Range(0, Capital.Length);
        wordOutput.text = Country[randomIndex];
        getAnswer();
    }

    void Update()
    {
        if (container == Capital[randomIndex] && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<AudioManager>().Play("right");
            clear();
            score++;
            scoreText.text = score.ToString();
            randomIndex = Random.Range(0, Capital.Length);
            wordOutput.text = Country[randomIndex];
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

    private void clear()
    {
        inputfieldname.Select();
        inputfieldname.text = "";
    }

    public void getAnswer()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitAnswer);
        input.onEndEdit = se;
    }

    private void SubmitAnswer(string arg0)
    {
        container = arg0;
    }
}