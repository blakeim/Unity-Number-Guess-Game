using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class NumberGame : MonoBehaviour {

    public InputField input;
    public Slider slider;
    public Text infoText;
    private int randomNumber;
    private int usersGuess;
    private int startingNum;

	void Start ()
    {
        startingNum = (int)slider.value;
        randomNumber = UnityEngine.Random.Range(0, startingNum);
	}

    void Update()
    {
        slider.handleRect.GetComponent<TextMesh>().text = slider.value.ToString("0");

        print(randomNumber);

        if ((int)slider.value != startingNum)
        {
            startingNum = (int)slider.value;
            randomNumber = UnityEngine.Random.Range(0, startingNum);
        }
    }

    public void CheckGuess()
    {
        usersGuess = int.Parse(input.text);

        if(usersGuess == randomNumber)
        {
            infoText.text = "Congratulations, you win!";
            randomNumber = UnityEngine.Random.Range(0, (int)slider.value);
        }
        else if (Math.Abs(randomNumber - usersGuess) <= 5)
        {
            String infoString = "Youre so close, ";
            infoString += checkBounds();
            infoText.text = infoString;
        }
        else if(Math.Abs(randomNumber - usersGuess) <= 20)
        {
            String infoString = "Getting warmer, ";
            infoString += checkBounds();
            infoText.text = infoString;
        }
        else
        {
            String infoString = "Not even close scrub, ";
            infoString += checkBounds();
            infoText.text = infoString;
        }

        input.text = "";
    }

    private String checkBounds()
    {
        if (usersGuess > randomNumber)
        {
            return "youre too high";
        }
        if (usersGuess < randomNumber)
        {
            return "youre too low";
        }
        else
        {
            return "This shouldn't have happened, the laws of mathematics may no longer apply. Praise Cthulu, lord of the sunken city";
        }
    }
}
