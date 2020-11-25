using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEnemy : MonoBehaviour
{

    public Color pathColor = Color.green;

    Transform[] objArray;
    public List<Transform> pathObjList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        //Gerade Gegnerbewegung
        Gizmos.color = pathColor;
        //füllen des Arrays mit Objekten (Zukünftigen Gegnern)
        objArray = GetComponentsInChildren<Transform>();
        //Löschen des Objekts
        pathObjList.Clear();
        //Löschen aller children in der Liste
        foreach(Transform obj in objArray)
        {
            if(obj !=this.transform)
            {
                pathObjList.Add(obj);
            }
        }
    }
}
