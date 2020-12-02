
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
 public PathEnemy pathToFollow; // greift auf das Script PathEnemy zu

//Path infos
public int currentWayPointID = 0;
public float speed = 2;
//ist die entfernung vom wegpunkt, wie genau der gegner den verfolgen soll (Radius)
 public float reachDistance = 0.4f;
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
    void MoveOnThePath(PathEnemy path)
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
            }
        }

    }
    
}