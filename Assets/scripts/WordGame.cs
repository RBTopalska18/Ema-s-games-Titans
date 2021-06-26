using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordGame
{
    //key - english, value - bulgarian
    public Dictionary<string, string> Words { get; set; }

    public WordGame()
    {
        Words = new Dictionary<string, string>();
        Words.Add("Hello", "Здравей"); //0
        Words.Add("Bye", "Довиждане"); //1
        Words.Add("Apple", "Ябълка"); //2
        Words.Add("Carrot", "Морков"); //3
        //Add more words by using Words.Add(english word, bulgarian word)
    }

    public KeyValuePair<string, string> GetRandomWord()
    {
        int randomIndex = Random.Range(0, Words.Count);
        return Words.ElementAt(randomIndex);
    }

}
