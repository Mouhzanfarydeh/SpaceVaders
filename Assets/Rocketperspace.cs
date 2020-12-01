using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocketperspace : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;

    //Rocket
    public Transform[] rocketSpawns;
    double nextFireRocket;
    int rocketcounter = 3;
    int rocketLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int rocketDamage = 3; // Später noch anpassbar
    public double RocketfireRate = 1; // Später noch anpassbar
    public GameObject rocket;

    // Update is called once per frame
    void Update()
    {
        // Rakete per leertaste schießen
        if (Input.GetKeyDown("space")) //&& 0 < rocketcounter;) /* isDragged &&  Time.time > nextFireRocket)  */ // hier noch anpassen das man nur eine gewisse Anzahl an Raketen hat
        {
            //rocketcounter i--;
            nextFireRocket = Time.time + RocketfireRate;
            for (int i = 0; i < rocketLevel; i++)
            {
                GameObject newRocket = Instantiate(rocket, rocketSpawns[i].position, rocketSpawns[i].rotation) as GameObject;
                // Bringt der Rakete Schaden
               // newRocket.GetComponent<Rocket>().SetDamage(rocketDamage);
            }
        }
        else
        {
         //   Console.WriteLine("Not enough rockets ");
        }
            
    }
}