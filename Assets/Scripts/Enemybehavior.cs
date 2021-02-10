using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemybehavior : MonoBehaviour
{
    //AOE
    public GameObject AOE;
    public bool Mothership = false;
    private Scene scene;
    public Path pathToFollow; // greift auf das Script Path zu

//Path infos
    public int currentWayPointID = 0;
    public float speed = 2;
//ist die entfernung vom wegpunkt, wie genau der gegner den verfolgen soll (Radius)
    public float reachDistance = 0.4f;
    public float rotationSpeed = 5f;

    public float detonationTimer = 0f;

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
    public int health;
    // weiter gehts in Zeile 100

    // Score
 //   public int inFormationScore;
      public int /* notinFormation */ Score;

    // Start is called before the first frame update
    public GameObject Object;
   // public Material[] Materials;
   // public static int currentMaterials;
    
    public Material Material0;
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public Material Material5;
    
    // public Material[] Materials;
    // public static int currentMaterials;
    // private GameObject Test;
    //public Renderer childColor;
    //public Material demagedMaterial;
    void Start()
    {
      //  Object.GetComponent<MeshRenderer>().material = Material0;
        //Skin für den Boss zurücksetzten           
        //childColor = GetComponentInChildren<MeshRenderer>();
        //GameObject Unterobjekt = transform.GetChild("Test").gameObject;
        // Test = GameObject.Find("Test");
        // Test<Renderer>().material = Materials[currentMaterials];
        //Test.renderer.material = Materials[currentMaterials];
        //GetComponent<MeshRenderer>().material = Materials[currentMaterials];
        //gameObject.GetComponent<MeshRenderer>().material = demagedMaterial;
        //childColor.material = demagedMaterial;
    }


    // Update is called once per frame
    void Update()
    {


        if (Mothership == true)
        { 
        if (health < 1300 && health > 1200)
        {
          Object.GetComponent<MeshRenderer>().material = Material0;
        }

        if (health < 1200 && health > 1040)
        {
          Object.GetComponent<MeshRenderer>().material = Material1;
        }

        if (health < 1040 && health > 780)
        {
          Object.GetComponent<MeshRenderer>().material = Material2;
        }

        if (health < 780 && health > 520)//(health < 600 && 400 > health)
        {
          Object.GetComponent<MeshRenderer>().material = Material3;
        }

        if (health < 520 && health > 260)
        {
          Object.GetComponent<MeshRenderer>().material = Material4;
        }

        if (health < 260 && health > 1)
        {
          Object.GetComponent<MeshRenderer>().material = Material5;
        }
        }


        switch (enemyState)
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

            formation.enemyList.Add(new Formation.EnemyFormation(enemyID, transform.localPosition.x, transform.localPosition.z, this.gameObject));

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

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Erhöhe Punltzahl
            if (enemyState == EnemyStates.IDLE) //bedeutet in der Formation 
            {
                GameManager.instance.AddScore(/*inFormation*/Score);
            }
            else
            { 
            GameManager.instance.AddScore(/*notFormation*/Score);
            }


            //Weitergeben an Formation
            for (int i = 0; i < formation.enemyList.Count; i++)
            {
                if(formation.enemyList[i].index == enemyID)
                {
                    formation.enemyList.Remove(formation.enemyList[i]);
                }
            }

            if (Mothership)
            {
                //Spawnt Mothership AOE
                Instantiate(AOE, transform.position, transform.rotation);
            }
            //Spawnt Mothership AOE
            //Instantiate(AOE, transform.position, transform.rotation);


            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);

            // weitergeben an Spawn Manager
            // SpawnManager sp = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); // ----------------------------------------------- noch verbuggt
            // sp.UpdateSpawnedEnemies(this.gameObject); //--------------------------------------------------------------------------------------
            
            //weitergeben an Game Manager
            GameManager.instance.ReduceEnemy();
  
        }
    }
}