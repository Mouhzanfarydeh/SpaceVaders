using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannon : MonoBehaviour
{
    //Bullet
    [Header("Player Bullets")]
    public Transform[] bulletSpawns;
    double nextFireBullet;
    int bulletLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int bulletDamage = 1; // Später noch anpassbar
    public double fireRate = 5; // Später noch anpassbar
    public float turnSpeed = 30.0f;
    public GameObject bullet;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( /* isDragged &&  */ Time.time > nextFireBullet) //&& !isDead)
        {

            // Findet den Spieler
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //Wenn Spieler nicht gefunden wurde drehe die Kanone
            if (player != null)
            {
                Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);

                //Drehen
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
            }

            nextFireBullet = Time.time + fireRate;
            for (int i = 0; i < bulletLevel; i++)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawns[i].position, bulletSpawns[i].rotation) as GameObject;
                // Bringt der Bullet Schaden
                newBullet.GetComponent<PlayerBullet>().SetDamage(bulletDamage);
            }
        }
    }
}
//   transform.position += transform.forward*speed*Time.deltaTime;