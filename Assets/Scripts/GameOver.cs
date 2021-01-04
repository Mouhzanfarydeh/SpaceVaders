using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text highscoreText;


    void Start()
    {
        highscoreText.text = "Highscore " + ScoreHolder.score;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) //der erste klick der Maus
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
