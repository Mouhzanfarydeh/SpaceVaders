using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public Color pathColor = Color.green;

    //Liste alle Gegner Kopien, die wird später ausgelesen vom Spawner
    Transform[] objArray;

    //Sensibilität der Kurve, Später noch einstellbar
    [Range(1, 20)] public int lineDensity = 1;
    int overload;

    public List<Transform> pathObjList = new List<Transform>();

    public List<Vector3> bezierObjList = new List<Vector3>();

    public bool visualizePath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // visualisierung der Gegnerwege (Einzeichnen)
    void OnDrawGizmos()
    {
      if(visualizePath)
      {     
        //Gerade Gegnerbewegung
        Gizmos.color = pathColor;
        //füllen des Arrays mit Objekten (Zukünftigen Gegnern)
        objArray = GetComponentsInChildren<Transform>();
        //Löschen des Objekts
        pathObjList.Clear();
        //Löschen aller children in der Liste, die füllt sich bis hier hin von alleine
        foreach(Transform obj in objArray)
        {
            if(obj !=this.transform)
            {
                pathObjList.Add(obj);
            }
        }
        // Einzeichnen der Wegpunkte mit Giz
        for (int i = 0; i < pathObjList.Count; i++)
        {
            Vector3 position = pathObjList[i].position;
            if(i>0)
            {
                // Speichern des Objekts auf den Punkt
                Vector3 previous = pathObjList[i - 1].position;
                //Von wo bis wo wird gezeichnet (von vorherige zur aktuellen)
                Gizmos.DrawLine(previous, position);
           
                Gizmos.DrawWireSphere(position, 2.0f);
            }
        }
        // Kurven Weg


        //check overload
        if(pathObjList.Count % 2 == 0)
        {
            // 4 > 2 > 0
            //gerade Zahlen
            pathObjList.Add(pathObjList[pathObjList.Count - 1]);
            overload = 2;
        }
        else
        {
            // 5 > 3 > 1
            //ungerade Zahlen
            pathObjList.Add(pathObjList[pathObjList.Count - 1]);
            pathObjList.Add(pathObjList[pathObjList.Count - 1]);
            overload = 3;
        }

        //clear der Liste, 
        bezierObjList.Clear();
        //erstelle start punkt für ersten loop
        Vector3 lineStart = pathObjList[0].position;
        //loop durch alle wegpunkte, overload (i+=2)
        for (int i = 0; i < pathObjList.Count-overload; i+=2)
        {
            for (int j = 0; j <= lineDensity; j++)
            {
                //beginnt vom ersten Punkt aus und geht dann zum 2 und dann zum 3 mit berücksichtigung der Kurven einstellung
                Vector3 lineEnd = GetPoint(pathObjList[i].position, pathObjList[i + 1].position, pathObjList[i + 2].position, j / (float)lineDensity); // (j / (float)lineDensity)    

                // Färbung des Pfades
                Gizmos.color = Color.red;
                Gizmos.DrawLine(lineStart, lineEnd);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(lineStart, 0.5f);

                lineStart = lineEnd;


                // verschiebung des Weges in die ObjList damit sich gegner darauf bewegen können
                bezierObjList.Add(lineStart);
            }
        }
      }
      else
      {
        pathObjList.Clear();
        bezierObjList.Clear();
      }
    }
    // p steht für pathpoint im pathholder 
    Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // erstellt eine Kurve beim linien ziehen
        return Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);
    }

    
}
