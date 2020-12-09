using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// wird automatisch auf den Player bezogen beim raufziehen des Scriptes
// Nur für Maus 

[RequireComponent (typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class PlayerBehaviour : MonoBehaviour
{
    // Nur für Maus

    /* bool isDragged; */
    // isDragged = true; //
    Vector3 screenPoint;
    Vector3 offset;



    //Bullet
    public Transform[] bulletSpawns;
    double nextFireBullet;
    int bulletLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int bulletDamage = 1; // Später noch anpassbar
    public double fireRate = 0.5; // Später noch anpassbar
    public GameObject bullet;
    // Leben vom Spieler
    public int health = 3;

    // Effect wenn Spieler zerstört wird
    public GameObject Explosion;


    // Update is called once per frame
    void Update()
    {
        if ( /* isDragged &&  */ Time.time > nextFireBullet)
        {
            nextFireBullet = Time.time + fireRate;
            for (int i = 0; i < bulletLevel; i++)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawns[i].position, bulletSpawns[i].rotation) as GameObject;
                // Bringt der Bullet Schaden
                newBullet.GetComponent<Bullet>().SetDamage(bulletDamage);
            }
        }

    }

    public void TakeDamage (int amount)
    {
        health += amount;

        if(health <= 0)
        {



            // Verliere Leben

            // check Gameover

            // Spiele Sound ab

            // Spiele Effect ab
            if(Explosion !=null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }
            
            // Zerstöre Spieler
            Destroy(gameObject);

        }

    }


 

    void OnTriggerEnter (Collider col)
    {
        if(col.CompareTag("Enemy"))
        {
           TakeDamage(-10);
        }
    }
    

}









// Movement Keyboard

/*
void Update()
{
    float x = Input.GetAxis("Horizontal");
float z = Input.GetAxis("Vertical");

Vector3 move = transform.right * x + transform.forward * z;

controller.Move(move* speed * Time.deltaTime);

velocity.y += gravity * Time.deltaTime;

controller.Move(velocity * Time.deltaTime);
}
*/


//Movement Mouse

/* void OnMouseDown()
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
 */

