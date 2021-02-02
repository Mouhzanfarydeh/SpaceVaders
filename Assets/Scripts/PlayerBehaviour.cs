using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// wird automatisch auf den Player bezogen beim raufziehen des Scriptes

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class PlayerBehaviour : MonoBehaviour
{

    private Scene scene;

    // public static PlayerBehaviour instance;

    // Nur für Maus

    /* bool isDragged; */
    // isDragged = true; //
    Vector3 screenPoint;
    Vector3 offset;

    // Player Movement
    [Header("Player Movement")]
    float speed = 27.2f;  // 23.0f ---> 27.2.0f
    public float gravity = 0;
    // Vector3 velocity;
    public int invert = 1; // Negative 1 for invert, positive 1 for not

    //Bullet
    [Header("Player Bullets")]
    public Transform[] bulletSpawns;
    double nextFireBullet;
    int bulletLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int bulletDamage = 1; // Später noch anpassbar
    double fireRate = 0.489; // Später noch anpassbar 0.5 ---> 0.489
    public GameObject bullet;

    [Header("Player")]
    // Leben vom Spieler
    public static int health = 3;
    public static int Life = 3;

    public Material[] Materials;
    public static int currentMaterials;

    public GameObject Rauchbei1Schaden;
    public GameObject Rauchbei2Schaden;

    //    public Texture[] textures; // Array was die Textures beinhaltet
    //    public int currentTexture; // Über den Wert wird bestimmt welche Texture angezeigt wird

    // Effect wenn Spieler zerstört wird
    public GameObject Explosion;
    public AudioClip HitSound;
    public AudioClip Alarm;

    //  public GameObject WarpEffect;

    //Resete Spieler
    Vector3 initPosition;
    bool isDead;

    void Start()
    {
        initPosition = transform.position; //Position an der das Schiff resetet wird

        scene = SceneManager.GetActiveScene();
        if (scene.name == "Stage1")
        {
            health = 3;
            Life = 3;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 3)
        {
            Rauchbei1Schaden.SetActive(false);
            Rauchbei2Schaden.SetActive(false);
        }

        if (health == 2)
        {
            Rauchbei1Schaden.SetActive(true);
            Rauchbei2Schaden.SetActive(false);
        }

        if (health == 1)
        {
            Rauchbei1Schaden.SetActive(false);
            Rauchbei2Schaden.SetActive(true);
        }





        /*
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(-1);
        }
        */
        /*
        if (health = 3)
        {
            currentTexture++;
            currentTexture %= textures.Length;
            renderer.material.mainTexture = textures[currentTexture];
        }
        if (health = 2)
        {
            currentTexture++;
            currentTexture %= textures.Length;
            renderer.material.mainTexture = textures[currentTexture];
        }
        if (health = 1)
        {
            currentTexture++;
            currentTexture %= textures.Length;
            renderer.material.mainTexture = textures[currentTexture];
        }
        */
        if (!isDead)
        {
            //New Movement 30.11.2020
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, invert * vertical, 0);
            Vector3 finaldirection = new Vector3(horizontal, invert * vertical, 6.0f);
         // Vector3 finaldirection = new Vector3(horizontal, invert * vertical, 10f);


            transform.position += direction * speed * Time.deltaTime;
        //  transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finaldirection), Mathf.Deg2Rad * 50.0f);

            //*************************************** limit position between -150x, 150x

            if (transform.position.x > 150)
                transform.position = new Vector3(150, transform.position.y, transform.position.z);
            if (transform.position.x < -150)
                transform.position = new Vector3(-150, transform.position.y, transform.position.z);

            if (transform.position.y > 40)
                transform.position = new Vector3(transform.position.x, 40, transform.position.z);
            if (transform.position.y < -20)
                transform.position = new Vector3(transform.position.x, -20, transform.position.z);





            // Old Movement (29.11.2020)
            /*
            float x = Input.GetAxis("Vertical");
            float z = Input.GetAxis("Horizontal");

            Vector3 move = transform.right * x  + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
            */
        }

        if ( /* isDragged &&  */ Time.time > nextFireBullet) //&& !isDead)
        {
            nextFireBullet = Time.time + fireRate;
            for (int i = 0; i < bulletLevel; i++)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawns[i].position, bulletSpawns[i].rotation) as GameObject;
                // Bringt der Bullet Schaden
                newBullet.GetComponent<PlayerBullet>().SetDamage(bulletDamage);
            }
        }

    }

    /*
    void OnTriggerEnter(Collider col) // wenn man mit was zusammenstößt, Kugeln, Gegner etc.
    {
        if (col.CompareTag("Enemy"))
        {
            TakeDamage(-1);
        }
    }
    */

    public void TakeDamage(int amount)
    {
        // health -= amount;
        health--;

        AudioSource.PlayClipAtPoint(HitSound, transform.position);

        currentMaterials++;
        currentMaterials %= Materials.Length;
        GetComponent<Renderer>().material = Materials[currentMaterials];




        GameManager.instance.DecreaseHealth();
        //renderer.material.mainMaterial = Materials[currentMaterials];

        if (health == 1)
        {

            AudioSource.PlayClipAtPoint(Alarm, transform.position);

        }

            if (health <= 0)
            {



            // Verliere Leben

            // check Gameover

            // Spiele Sound ab

            // Spiele Effect ab
            if (Explosion != null) //bedeutet wenn der Slot nicht mit einen Prefab gefüllt ist, passiert nichts
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

              // Zerstöre Spieler
              //Destroy(gameObject);
               StartCoroutine(Reset());

            }
    }

    IEnumerator Reset() //Koroutine
    {
        GameManager.instance.DecreaseLifes(); //Verändert die Anzahl der Leben im UI
        GetComponent<MeshRenderer>().enabled = false; //Greift auf das SpielerSchiff zu und schaltet es aus
        GetComponent<Collider>().enabled = false;

        isDead = true;

        transform.position = initPosition;

        yield return new WaitForSeconds(0.1f); //warte 0.1 sekunden ab bevor man sich wieder bewegen kann

        GetComponent<MeshRenderer>().enabled = true; //Greift auf das SpielerSchiff zu und schaltet es an
        GetComponent<Collider>().enabled = true;
        isDead = false;
        health = 3;
        GameManager.instance.HealingHealth();
    }

    /*
     public void WarpJump() 
     {
         //if (WarpEffect != null) //bedeutet wenn der Slot nicht mit einen Prefab gefüllt ist, passiert nichts
         //{
            Instantiate(WarpEffect, transform.position, Quaternion.identity);
         //}
     }
    */
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

