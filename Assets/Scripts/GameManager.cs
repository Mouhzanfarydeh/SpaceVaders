using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //private int nextSceneToLoad;

    // static damit es gespeichert wird und sich nicht verändert wenn die nächste level beginnt

    static int level = 1; // aktuelle Level
    static int score = 0;
    static int lifes = 3;
    static int rocket = 3; //------------------------------------------------- neu hinzugefügt
    static int health = 3;

    /*
    Rocketperspace rocketimUI;
    void start()
    { 
    rocketimUI = GameObject.Find("wasp").GetComponent<Rocketperspace>();
    Debug.Log(rocketimUI.rocketsleft);
    }
    */

    // Anzahl der Gegner in der Scene
    int enemyAmount;

    // Extraleben nach bestimmter Punktzahl
    public int scoreToBonusLife = 10000; //später noch anpassbar

    // Punktzahl nach zerstörung der Gegner
    static int bonusScore;

    //Prüfen ob man noch nicht verloren hat
    static bool hasLost;

    void Awake()
    {
        instance = this; //sichgehen das Game Manager existiert

        //Reset der Level
        if (hasLost)
        {
            level = 1;
            score = 0;
            lifes = 3;
            rocket = 3;
            health = 3;
            bonusScore = 0;
            hasLost = false;
        }

    }
    /*
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1);
    }
   */
    void Start()
    {
        UiScript.instance.UpdateScoreText(score);
        UiScript.instance.UpdateLifeText(lifes);
        UiScript.instance.ShowStageText(level);
        UiScript.instance.UpdateRocketText(rocket);
        UiScript.instance.UpdateHealthText(health);
    }

    public void AddScore(int amount)
    {
        score += amount;
        //Debug.Log(score);

        // Verändert Score im Ui
        UiScript.instance.UpdateScoreText(score);

        bonusScore += amount;
        if (bonusScore >= scoreToBonusLife)
        {
            lifes++;
            //   bonusScore = 0; Problem = Beispiel Gegner besiegt man bekommt 300 Punkte  + 90800 Ergebniss = Reset auf 0 anstatt auf 100 Punkte
            bonusScore %= scoreToBonusLife; // Ergebniss wird dadurch genauer
        }
    }

    public void DecreaseHealth()
    {
        health--;

        UiScript.instance.UpdateHealthText(health);

        if (health <=0)
        {
            health = 3;
        }
    }

   public void DecreaseRockets()
    {      
        rocket--;

        UiScript.instance.UpdateRocketText(rocket);
    }

    public void DecreaseLifes()
    {
        lifes--;

        UiScript.instance.UpdateLifeText(lifes);

        if (lifes <=0)
        {
            // Game Over - Losing Condition
            //ScoreHolder.level = level; ----------------------- unfertig, zeigt an in welcher level spieler gestorben ist
            ScoreHolder.score = score;
            hasLost = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    //Wird erhöht wenn Gegner erscheint
    
    public void AddEnemy()
    {
        enemyAmount++;
    }

    //Wird gesenkt wenn Gegner verschwindet
    public void ReduceEnemy()
    {
        enemyAmount--;
        if (enemyAmount <= 0)
        {
            ScoreHolder.score = score;
            // Prüfung der Siegesbedingungen
            level++;
         //SceneManager.LoadScene("Stage2");
         //SceneManager.LoadScene(nextSceneToLoad);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
    /*
    public void WinCondition()
    {
        // Prüfung der Siegesbedingungen
        level++;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //startet nächste Stage(Level/Scene)
         SceneManager.LoadScene("Stage2"); // hier nächste level hinzufügen
    }
    */
}