using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutofire : MonoBehaviour
{

    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject EnemyBulletSpawner;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Kugel;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    public float FireRate;

    double nextFireBullet;


    void Start()
    {

    }

    void Update()
    {
        // if (Input.GetKeyDown("space"))
        if ( /* isDragged &&  */ Time.time > nextFireBullet)
        {
            nextFireBullet = Time.time + FireRate;


            //The Bullet instantiation happens here.
            // "Kugel" schould be "EnemyBullet"
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Kugel, EnemyBulletSpawner.transform.position, EnemyBulletSpawner.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds
            // needs to get destroyed when hiting
            Destroy(Temporary_Bullet_Handler, 5.0f);
        }

       // if ( /* isDragged &&  */ Time.time > nextFireBullet)
        //{
        //    nextFireBullet = Time.time + fireRate;
        //    for (int i = 0; i < bulletLevel; i++)
        //    {
        //        GameObject newBullet = Instantiate(bullet, bulletSpawns[i].position, bulletSpawns[i].rotation) as GameObject;
        //         Bringt der Bullet Schaden
        //        newBullet.GetComponent<Bullet>().SetDamage(bulletDamage);
        //    }
        //}
    }
}
