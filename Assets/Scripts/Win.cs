﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    public Text highscoreText;


    void Start()
    {
        highscoreText.text = " " + ScoreHolder.score;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) //der erste klick der Maus
        {
            SceneManager.LoadScene("Credits");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
