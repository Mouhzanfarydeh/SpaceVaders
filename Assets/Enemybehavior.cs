
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
 public Path pathToFollow; // greift auf das Script Path zu

//Path infos
public int currentWayPointID = 0;
public float speed = 2;
//ist die entfernung vom wegpunkt, wie genau der gegner den verfolgen soll (Radius)
public float reachDistance = 0.4f;
public float rotationSpeed = 5f;

    float distance; // Distanz zum nächsten Wegpunkt
    // für zickzack movement (use Bezier Path and not pass points)
    public bool useBezier = false;

    //State machine
    public enum EnemyStates
    {
        ON_PATH, //Bewegt sich auf Pfad
        FLY_IN, // Bewegt sich zur Formation
        IDLE // Bewegt sich in Formation
    }
    public EnemyStates enemyState;

    public int enemyID; //ist die Position in der Formation
    public Formation formation; //hier platz in der Formation reinlegen wo das Schiff hin fliegen soll

    // Effect wenn Gegner zerstört wird
    public GameObject Explosion;

    // Leben der Gegner
    public int health = 1;
    // weiter gehts in Zeile 100

    // Score
 //   public int inFormationScore;
      public int /* notinFormation */ Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
   void Update()
    {
        switch(enemyState)
        {
            case EnemyStates.ON_PATH:
                MoveOnThePath(pathToFollow);
                break;
            case EnemyStates.FLY_IN:
                MoveToFormation();
                break;
            case EnemyStates.IDLE:

                break;
        }
    }

    void MoveToFormation()
    {
        transform.position = Vector3.MoveTowards(transform.position, formation.GetVector(enemyID), speed * Time.deltaTime);

        //Rotation
        // Gegner schaut immer in Flugrichtung beim bewegen
        /*   var direction = formation.GetVector(enemyID) - transform.position;
           if(direction != Vector 3.zero)
           {
               direction.y = 0
               direction = direction.normalized;
               var rotation = Quaternion.LookRotation(direction);
               transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
           } */

        //Prüfen der Distanz zum Ziel
        if (Vector3.Distance(transform.position,formation.GetVector(enemyID)) <= 0.0001f)
        //SwitchState
        {
            transform.SetParent(formation.gameObject.transform); // Gegner werden Unterobjecte der Formation
            transform.eulerAngles = new Vector3(0, 0, 0); //= Vector3.zero;

            enemyState = EnemyStates.IDLE;
            // Dreht sich zum Spieler hin
        }
    }


    void MoveOnThePath(Path path)
    {
        // wenn Bezier angeschaltet ist, Gegner bewegt sich zum ersten Wegpunkt
        if (useBezier)
        {
            distance = Vector3.Distance(path.bezierObjList[currentWayPointID], transform.position);
            transform.position = Vector3.MoveTowards(transform.position, path.bezierObjList[currentWayPointID], speed * Time.deltaTime);

            // Gegner schaut immer in Flugrichtung beim bewegen
         /*   var direction = path.bezierObjList[currentWayPointID] - transform.position;
            if(direction != Vector 3.zero)
            {
                direction.y = 0
                direction = direction.normalized;
                var rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            } */
        }
        else
        {
        // Gegner bewegt sich zum ersten Wegpunkt
        distance = Vector3.Distance(path.pathObjList[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path.pathObjList[currentWayPointID].position, speed * Time.deltaTime);

            // Gegner schaut immer in Flugrichtung beim bewegen
            /*   var direction = path.path.pathObjList[currentWayPointID].position - transform.position;
               if(direction != Vector 3.zero)
               {
                   direction.y = 0
                   direction = direction.normalized;
                   var rotation = Quaternion.LookRotation(direction);
                   transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
               } */
        }
        // Bewegung zum nächsten Wegpunkt
        if (useBezier)
        {
            if (distance <= reachDistance)
            {
                currentWayPointID++;
            }

            if (currentWayPointID >= path.bezierObjList.Count)
            {
                currentWayPointID = 0;
                enemyState = EnemyStates.FLY_IN; // Befehl fliegt anschließend in eine Position in der Formation
            }
        }
        else
        {
            if (distance<=reachDistance)
            {
                currentWayPointID++;
            }

            if(currentWayPointID>= path.pathObjList.Count)
            {
                currentWayPointID = 0;
                enemyState = EnemyStates.FLY_IN; // Befehl fliegt anschließend in eine Position in der Formation
            }
        }

    }

    //Automatisieren des bewegen auf Pfad
    public void SpawnSetup(Path path, int ID, Formation _formation) // eventuell muss man auch Path einstellen
    {
        pathToFollow = path;
        enemyID = ID;
        formation = _formation;
    }




    // genommener Schaden
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health<=0)
        {
            // Verliere Leben

            // Spiele Sound ab

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Zerstöre Spieler
            Destroy(gameObject);


           // GameManager.instance.AddScore(Score);
            // Erhöhe Punltzahl
            /*  if(enemyState == EnemyStates.IDLE) //bedeutet in der Formation erst mal nicht umsetzten
            {
            GameManager.instance.AddScore(inFormationScore);
            else...
            }
            */

            //  GameManager.instance.AddScore(Score); //(NotinFormationScore);
            //  }








            //weitergeben an Game Manager
            //  GameManager.instance.ReduceEnemy();

        }
    }
}