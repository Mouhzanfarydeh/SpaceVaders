using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyFire : MonoBehaviour
{
    //Bullet
    [Header("Player Bullets")]
    public Transform[] bulletSpawns;
    double nextFireBullet;
    int bulletLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int bulletDamage = 1; // Später noch anpassbar
    public double fireRate = 0.5; // Später noch anpassbar
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( /* isDragged &&  */ Time.time > nextFireBullet) //&& !isDead)
        {
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
