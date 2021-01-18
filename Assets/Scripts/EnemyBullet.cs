using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class EnemyBullet : MonoBehaviour
{
    public int damage;
    public float speed = 25f; // geschwindigkeit der Schüsse, später noch anpassbar (muss man erst mal testen)

   // public AudioClip deathClip;

    void Start()
    {
        // zerstöre Kugel nach 9 Sekunden
        Destroy(gameObject, 8f);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
  
    public void SetDamage (int amount)
    {
        damage = amount;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerBehaviour>().TakeDamage(damage);

            // Spiele Sound ab
            //AudioSource.deathClip.Play();
           // AudioSource.PlayClipAtPoint(deathClip, transform.position);

            //Danach zerstöre Geschoss
            Destroy(gameObject);
        }
    }
}