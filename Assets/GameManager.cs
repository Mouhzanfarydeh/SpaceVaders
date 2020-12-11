using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    // static damit es gespeichert wird und sich nicht verändert wenn die nächste level beginnt

    static int level = 1; // aktuelle Level
    static int score;
    static int lifes = 3;

    // Anzahl der Gegner in der Scene
    int enemyAmount;

    // Extraleben nach bestimmter Punktzahl
    int scoreToBonusLife = 10000; //später noch anpassbar

    // Punktzahl nach zerstörung der Gegner
    static int bonusScore;

    //Prüfen ob man noch nicht verloren hat
    static bool hasLost;

    void Awake()
    {
        instance = this; //sichgehen das Game Manager existiert
    }

    void Update()
    {
        UiScript.instance.UpdateScoreText(score);
        UiScript.instance.UpdateLifeText(lifes);
        UiScript.instance.ShowStageText(level);


        //Reset der Level
        if (hasLost)
        {
            level = 1;
            score = 0;
            lifes = 3;
            bonusScore = 0;
            hasLost = false;
        }

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

    public void DecreaseLifes()
    {
        lifes--;

        UiScript.instance.UpdateLifeText(lifes);

        if (lifes < 0)
        {
            // Game Over - Losing Condition
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
            // Prüfung der Siegesbedingungen
        }
    }

    }
