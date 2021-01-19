using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   // public GameManager myGameManager; //Neues Objekt anlegen

    /*
    public static int level; // aktuelle Level
    public static int score;
    public static int lifes;
    public static int rocket; //------------------------------------------------- neu hinzugefügt
    public static int health;
    public static int bonusScore;
    */

 //   void Start()
  //  {
      // Debug.Log(myGameManager.level);

        //myGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        /*
        level = 1;
        score = 0;
        lifes = 3;
        rocket = 3;
        health = 3;
        bonusScore = 0;
        */
  //  }


    public void PlayGame()
    {
        //SceneManager.LoadScene("Stage1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Resetet Level nicht
        //Application.LoadLevel(Application.loadedlevel);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
            Application.Quit();
    }

}