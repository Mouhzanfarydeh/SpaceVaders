using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    int damage;
    public float speed = 10f; // geschwindigkeit der Schüsse, später noch anpassbar (muss man erst mal testen)


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void SetDamage(int amount)
    {
        damage = amount;

    }
}
