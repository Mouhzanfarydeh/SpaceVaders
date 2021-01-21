using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueshell : MonoBehaviour
{

        Rigidbody rb;

        public float speed = 0f; //12f ---> 29f

        private Transform target;

        public float rotateSpeed = 0f;


    public GameObject Explosion;
    public int damage = 1;
    public int health = 1;
    public int Score;


        void Start()
        {

            rb = GetComponent<Rigidbody>();

            target = GameObject.FindGameObjectWithTag("Player").transform;

            Destroy(gameObject, 22f); // 20f ---> 22f


        }

        // Update is called once per frame
        void Update()
        {



          // transform.position = Vector3.MoveTowards(transform.position, formation.GetVector(enemyID), speed * Time.deltaTime);



           Vector3 direction = (Vector3)target.position - rb.position;

            direction.Normalize();

            Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.forward * speed;

        }

        // Update is called once per frame
      //  void Update()
      //  {
            // Drehe die Kamera jedes Bild, damit sie immer auf das Ziel schaut
        //    transform.LookAt(Target);

            // Wie oben, aber wenn Sie den Parameter worldUp in diesem Beispiel auf Vector3.left setzen, wird die Kamera auf die Seite gedreht
      //      transform.LookAt(Target, Vector3.left);
    //    }
    
        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerBehaviour>().TakeDamage(damage);

            // Spiele Sound ab
            //AudioSource.deathClip.Play();
            // AudioSource.PlayClipAtPoint(deathClip, transform.position);
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }
            //Danach zerstöre Geschoss
            Destroy(gameObject);
            }
        }
    
    

    public void TakeDamage(int amount)
    {
        health--;
        if (health <= 0)
        {
            // Verliere Leben

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // GameManager.instance.AddScore(Score);

            // Zerstöre Gegner
            Destroy(gameObject);

            // weitergeben an Spawn Manager
            // SpawnManager sp = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); // ----------------------------------------------- noch verbuggt
            // sp.UpdateSpawnedEnemies(this.gameObject); //--------------------------------------------------------------------------------------

            //weitergeben an Game Manager
           // GameManager.instance.ReduceEnemy();

        }
    }

}
