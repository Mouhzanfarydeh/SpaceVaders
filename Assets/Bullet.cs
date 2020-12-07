using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed = 10f; // geschwindigkeit der Schüsse, später noch anpassbar (muss man erst mal testen)

    // zerstöre Kugel nach 10 Sekunden
    void Start()
    {
        Destroy(gameObject, 10f);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
  

    // verbunden mit Enemybehavior zeile 100
    public void SetDamage (int amount)
    {
        damage = amount;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemybehavior>().TakeDamage(damage);

            //Danach zerstöre Geschoss
            Destroy(gameObject);
        }
    }
}
