using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocketperspace : MonoBehaviour
{
    private Scene scene;

    Vector3 screenPoint;
    Vector3 offset;

    //Rocket
    public Transform[] rocketSpawns;
    double nextFireRocket;

    //GameManager rocketimUI;

    public static int rocketsleft = 3;
    int rocketLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int rocketDamage = 3; // Später noch anpassbar
    public double RocketfireRate = 1; // Später noch anpassbar
    public GameObject rocket;

    void start()
    { 
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Stage1")
        {

            rocketsleft = 3;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rakete per leertaste schießen
        if (Input.GetKeyDown("space") && rocketsleft > 0) // hier noch anpassen das man nur eine gewisse Anzahl an Raketen hat
        {
            GameManager.instance.DecreaseRockets();

            rocketsleft--;
            nextFireRocket = Time.time + RocketfireRate;
            for (int i = 0; i < rocketLevel; i++)
            {
                GameObject newRocket = Instantiate(rocket, rocketSpawns[i].position, rocketSpawns[i].rotation) as GameObject;
                // Bringt der Rakete Schaden
                newRocket.GetComponent<Rocket>().SetDamage(rocketDamage);
            }
        }
    }

    /*
    void start()
    {
        rocketimUI = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log(rocketimUI.rocket);
    }
    */

}