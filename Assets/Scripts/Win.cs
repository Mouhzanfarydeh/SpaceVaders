using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    public Text highscoreText;
    public Image Highscore;
    public Image winText;

    void Start()
    {
        highscoreText.text = " " + ScoreHolder.score;

        Invoke("DisableText", 3f);//invoke after 5 seconds

    }

    void DisableText()
    {
        highscoreText.enabled = false;
        winText.enabled = false;
        Highscore.enabled = false;
    }



    void Update()
    {
        if(Input.GetMouseButton(0)) //der erste klick der Maus
        {
            SceneManager.LoadScene("Menu Jul");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu Jul");
        }
    }
}
