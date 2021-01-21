using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    Vector3 temp;
    public int damage;
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;

        temp.x += Time.deltaTime* 150f;
        temp.y += Time.deltaTime* 150f;
        temp.z += Time.deltaTime* 150f;

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
