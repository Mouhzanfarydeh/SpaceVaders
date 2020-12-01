/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
 public Path pathToFollow;
//Path infos
public int currentWayPointID = 0;
public float Enemyspeed = 2;
//ist die entfernung vom wegpunkt, wie genau der gegner den verfolgen soll (Radius)
public float reachDistance 0.4f;
 public float rotationSpeed = 5f;

    float distance; // Distanz zum nächsten Wegpunkt
    // für zickzack movement (use Bezier Path and not pass points)
    public bool useBezier = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
       MoveOnThePath(pathToFollow);
    }
    void MoveOnThePath(Path path)
    {
        distance = Vector3.Distance(path.pathObjList[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path.pathObjList[currentWayPointID].position, Enemyspeed * Time.deltaTime);
    }
}






using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Enemybehavior : MonoBehaviour

{

    public Path pathToFollow;

    public int currentPointID = 0;

    public float speed = 2;

    public float reachDistance = 0.4f;

    public float rotateSpeed = 5f;



    float distance;

    //distance to next point



    public bool useBezier = false;





    void Start()



    {



    }



    // Update is called once per frame

    void Update()

    {

        MoveOnThePath(pathToFollow);

    }

    void MoveOnThePath(Path path)

    {

        distance = Vector3.Distance(path.pathObjList[currentPointID].position, transform.position);

        transform.position = Vector3.MoveTowards(transform.position, path.pathObjList[currentPointID].position, speed * Time.deltaTime);

    }

}
*/