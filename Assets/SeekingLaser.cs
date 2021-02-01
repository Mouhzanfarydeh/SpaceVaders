using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingLaser : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSpeed = 30.0f;
    public float startSeeking = 1.0f;
    public float stopSeeking = 4.0f;

    private float t = 0.0f;

 //   private Transform target;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(t > startSeeking && t < stopSeeking)
        {
           //transform.parent = null;
           // Findet den Spieler
            GameObject player = GameObject.FindGameObjectWithTag("Player"); 
           // target = GameObject.FindGameObjectWithTag("Player").transform;
            if (player != null)
            { 
                Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);

            //Drehen
            transform.rotation = Quaternion.RotateTowards(transform.rotation,newRotation,turnSpeed * Time.deltaTime);
            }
        }
    

    //Vorwärts
   transform.position += transform.forward*speed*Time.deltaTime;
    }
}
