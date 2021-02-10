using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    Vector3 temp;
    public int damage;
    public float growthspeed;
    public float lifetime = 1f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;

        temp.x += Time.deltaTime* growthspeed;
        temp.y += Time.deltaTime* growthspeed;
        temp.z += Time.deltaTime* growthspeed;

        transform.localScale = temp;
    }
    public void SetDamage(int amount)
    {
        damage = amount;
    }
    void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Enemy")
            {
            col.gameObject.GetComponent<Enemybehavior>().TakeDamage(damage);
            }

            if (col.tag == "Mine")
            {
            col.gameObject.GetComponent<EnemyBlueshell>().TakeDamage(damage);
            }
        }
    }
