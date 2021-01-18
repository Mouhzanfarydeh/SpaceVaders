using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class PlayerBullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 28f; // geschwindigkeit der Schüsse, später noch anpassbar (muss man erst mal testen)

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
