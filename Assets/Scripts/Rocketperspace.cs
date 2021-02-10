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
    double nextFireRocket = 0.0001;

    //GameManager rocketimUI;

    public static int rocketsleft = 3;
    int rocketLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int rocketDamage = 3; // Später noch anpassbar
    public double RocketfireRate = 1; // Später noch anpassbar
    public GameObject rocket;
    public AudioClip Empty;

    void Start()
    { 
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Stage1")
        {
            rocketsleft = 3;
        }
        if (scene.name == "Stage2")
        {
            rocketsleft++;
            rocketsleft++;
            rocketsleft++;
        }
        if (scene.name == "Stage3")
        {
            rocketsleft++;
            rocketsleft++;
            rocketsleft++;
        }
        if (scene.name == "Stage4")
        {
            rocketsleft++;
            rocketsleft++;
            rocketsleft++;
        }
        if (scene.name == "Stage5")
        {
            rocketsleft++;
            rocketsleft++;
            rocketsleft++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireRocket)
        { 
            // Rakete per leertaste schießen
            if (Input.GetKeyDown("space") && rocketsleft > 0) // hier noch anpassen das man nur eine gewisse Anzahl an Raketen hat
        {
            GameManager.instance.DecreaseRockets();

           // rocketsleft -= 1;
            rocketsleft--;
            nextFireRocket = Time.time + RocketfireRate;
            for (int i = 0; i < rocketLevel; i++)
            {
                GameObject newRocket = Instantiate(rocket, rocketSpawns[i].position, rocketSpawns[i].rotation) as GameObject;
                // Bringt der Rakete Schaden
                newRocket.GetComponent<Rocket>().SetDamage(rocketDamage);
            }
        }

        if (Input.GetKeyDown("space") && rocketsleft == 0) //Wenn man 0 Raketen hat und Spcae drückt, spiele Sound ab
        {

            AudioSource.PlayClipAtPoint(Empty, transform.position);
        }
        }
    }
    

}