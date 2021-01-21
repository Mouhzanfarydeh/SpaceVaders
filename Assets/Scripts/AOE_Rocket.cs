using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class AOE_Rocket : MonoBehaviour
{
    public int damage;
    public float speed = 20f; // geschwindigkeit der Schüsse, später noch anpassbar (muss man erst mal testen)
    public GameObject AOE;

    // zerstöre Rakete nach 10 Sekunden
    void Start()
    {
        Destroy(gameObject, 10f);
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3.forward heißt Vorwärts in der Welt bewegen
        //transform.forward heißt bewegt das game object nach vorne
        transform.Translate(transform.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    // verbunden mit Enemybehavior zeile 100
    public void SetDamage(int amount)
    {
        damage = amount;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Instantiate(AOE);
            //col.gameObject.GetComponent<Enemybehavior>().TakeDamage(damage);
        }

        if (col.tag == "Mine")
        {
            Instantiate(AOE);
            //col.gameObject.GetComponent<EnemyBlueshell>().TakeDamage(damage);
        }

        //Danach zerstöre Geschoss
        Destroy(gameObject);


    }
}
