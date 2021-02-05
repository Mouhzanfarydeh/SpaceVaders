using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerBehaviour ändern;
    public static GameManager instance;

    public GameObject Warpeffect;

    public GameObject wasp;

    private Scene scene;

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
    
    void Update()
    {

     // UiScript.instance.UpdateScoreText(score);
        UiScript.instance.UpdateLifeText(lifes);
     // UiScript.instance.ShowStageText(level);
        UiScript.instance.UpdateRocketText(rocket); //-------------------------*** Erst mal testen
        UiScript.instance.UpdateHealthText(health);
    }
    

    void Start()
    {

        scene = SceneManager.GetActiveScene();
        if (scene.name == "Stage1")
        { 

        level = 1;
        score = 0;
        lifes = 3;
        rocket = 3;
        health = 3;
        bonusScore = 0;

        }
    /*
    level = 1;
    score = 0;
    lifes = 3;
    rocket = 3;
    health = 3;
    bonusScore = 0;
    */


        UiScript.instance.UpdateScoreText(score);
        UiScript.instance.UpdateLifeText(lifes);
        UiScript.instance.ShowStageText(level);
        UiScript.instance.UpdateRocketText(rocket);
        UiScript.instance.UpdateHealthText(health);
        

        Warpeffect.SetActive(false);
        //GetComponent<Warp>();

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
            ändern = GameObject.Find("wasp").GetComponent<PlayerBehaviour>();
            ändern.Bonusss(); //führe void Bonusss aus
            // Life++; //ändern Lebenswert im Player
            lifes++;
            //   bonusScore = 0; Problem = Beispiel Gegner besiegt man bekommt 300 Punkte  + 90800 Ergebniss = Reset auf 0 anstatt auf 100 Punkte
            bonusScore %= scoreToBonusLife; // Ergebniss wird dadurch genauer
        }
    }

    public void HealingHealth()
    {
        health++;
        health++;
        health++;
        
        UiScript.instance.UpdateHealthText(health);
        return;

    }

    public void DecreaseHealth()
    {
        health--;

        UiScript.instance.UpdateHealthText(health);

        /*
        if (health <=0)
        {
            health = 3;
        }
        */
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

        if (lifes == 0)
        {
            // Game Over - Losing Condition
            //ScoreHolder.level = level; ----------------------- unfertig, zeigt an in welcher level spieler gestorben ist
            ScoreHolder.score = score;
            hasLost = true;
            SceneManager.LoadScene("GameOver");
            // StartCoroutine(wait());
            // SceneManager.LoadScene("GameOver");
            //Invoke("LoadEnd", 5f);
            return;
        }
    }

    /*
    void LoadEnd()
    {
        SceneManager.LoadScene("GameOver");
    }
    */
        //Wird erhöht wenn Gegner erscheint

    public void AddEnemy()
    {
        enemyAmount++;
    }

    /*
    IEnumerator Waitamoment() //Koroutine
    {
        // Gibt die Zeit aus, zu der die Funktion zum ersten Mal aufgerufen wird.
        Debug.Log(" Coroutine zum Zeitstempel gestartet :" + Time.time);

        yield return new WaitForSeconds(5); //warte 5 sekunden ab bevor nächste stage lädt

        // Nachdem wir 5 Sekunden gewartet haben, drucke die Zeit erneut.
        Debug.Log("Fertige Coroutine zum Zeitstempel:" + Time.time);

    }
    */
    //Wird gesenkt wenn Gegner verschwindet
    public void ReduceEnemy()
    {
        enemyAmount--;
        if (enemyAmount <= 0) // Prüfung der Siegesbedingungen
        {
            ScoreHolder.score = score;

            Warpeffect.SetActive(true);
            
            //gameObject.SetActive(true);
            //Instantiate(WarpEffect, transform.position, Quaternion.identity);

            // else
            //   {
            // gameObject.SetActive(false);
            //  }
            //  }











            // GameObject LetsJump;

            //  LetsJump = GameObject.Find("Warp");
            // Jump = true;


            // Warpjump = GetComponent<Warp>();
            //PlayerBehaviour = WarpEffect.GetComponent<Warp>();



            //gameObject.SetActive(true);


            //ScriptA.X = true;
            //Warp.Jump = true;

            //    if (Warp.Jump)
            //    {
            //  Jump = true;
            //   }






            //PlayerBehaviour = WarpEffect.GetComponent<PlayerBehaviour>();
            // GetComponent<Renderer>().material = Materials[currentMaterials];

            // StartCoroutine(WarpJump());
            /*
            void WarpJump()
            {
                if (WarpEffect != null) //bedeutet wenn der Slot nicht mit einen Prefab gefüllt ist, passiert nichts
                {
                   Instantiate(WarpEffect, transform.position, Quaternion.identity);
                }
            }
            */
            //Invoke("WarpJump", 1f); //Zeitstempel funktionieren nicht weil es erst bei der nächsten aktualisierung ausgeübt wird

            // Debug.Log("Fertige Coroutine zum Zeitstempel:" + Time.time);
            // UiScript.instance.UpdateRocketText(rocket);
            // PlayerBehaviour.instance.WarpJump();

            Invoke("LoadNextScene", 5f);

            rocket++;
            rocket++;
            rocket++;

            wasp.GetComponent<PlayerBehaviour>().enabled = false;
            return;
            //wasp.SetActive(false);


            //PlayerBehaviour Wasp = GetComponent<PlayerBehaviour>();
            //StartCoroutine (Wasp.Reset());
            //StartCoroutine(Reset());

            // StartCoroutine(Jump());
            //level++;

            //SceneManager.LoadScene("Stage2");
            //SceneManager.LoadScene(nextSceneToLoad);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    /*
    IEnumerator Jump() //Koroutine
    {
        //Greift auf das SpielerSchiff zu und schaltet es aus
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f); //warte 5 sekunden ab bevor man sich wieder bewegen kann

        GetComponent<Collider>().enabled = true;

    }
    */

    void LoadNextScene()
    {
        level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   // IEnumerator wait() //Koroutine
   // {
        //wasp.GetComponent<PlayerBehaviour>().enabled = false;
        //yield return new WaitForSeconds(0.2f); //warte 0.2 sekunden ab 
        //SceneManager.LoadScene("GameOver");
    //}

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