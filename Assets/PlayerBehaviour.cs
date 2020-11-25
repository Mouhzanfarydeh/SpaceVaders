using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// wird automatisch auf den Player bezogen beim raufziehen des Scriptes
[RequireComponent (typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerBehaviour : MonoBehaviour
{
    bool isDragged;
    Vector3 screenPoint;
    Vector3 offset;

    //Bullet
    public Transform[] bulletSpawns;
    double nextFireBullet;
    int bulletLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int bulletDamage = 1; // Später noch anpassbar
    public double fireRate = 0.5; // Später noch anpassbar
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Der Teil ist verbuggt und muss noch gelöst werden, kümmere mich später darum...
    // könnte daran liegen das dass Array in den Minus bereich geht https://answers.unity.com/questions/1238243/how-do-i-fix-index-out-of-range-exception-error.html#:~:text=Generally%20%40masonb21%2C%20Array%20out%20of,1%20length%20of%20the%20array.
    
    // Update is called once per frame
    
    void Update()
    {
        if(isDragged && Time.time > nextFireBullet)
        {
            nextFireBullet = Time.time + fireRate;
            for (int i = 0; i < bulletLevel;  i++)
            {
               GameObject newBullet = Instantiate(bullet, bulletSpawns[i].position, bulletSpawns[i].rotation) as GameObject;
                // Bringt der Bullet Schaden
    newBullet.GetComponent<Bullet>().SetDamage(bulletDamage);
            }
        }
    }
    
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    

      void OnMouseDrag()
       {
           Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
           Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

           isDragged = true;
           transform.position = curPosition;

       }

       void OnMouseUp()
       {
           isDragged = false;
       }
    
}
