using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class TypeScript : MonoBehaviour
{
    public Text wordOutput;
    public Text scoreText;
    private string container;
    public InputField inputfieldname;

    private string[] bg = {"здравей","довиждане","ябълка","морков"};
    private string[] en = { "Hello", "Bye", "Apple", "Carrot"};
    private int randomIndex;
    private int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
        randomIndex = Random.Range(0, bg.Length);
        wordOutput.text = en[randomIndex];
        getAnswer();
    }

    void Update()
    {
        if(container == bg[randomIndex] && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<AudioManager>().Play("right");
            clear();
            score++;
            scoreText.text = score.ToString();
            randomIndex = Random.Range(0, bg.Length);
            wordOutput.text = en[randomIndex];
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