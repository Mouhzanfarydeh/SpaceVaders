using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Formation : MonoBehaviour
{
    //Größe des Gitternetz
    public int gridSizeBreiteX = 10; // 10 Felder pro Reihe in die Breite
    public int gridSizeLängeZ = 2; // 2 Reihen nach hinten in die Länge
    public int gridSizeHöheY = 3; // Test Höhe

    public float gridOffsetX = 1f; //Abstand zum nächsten 
    public float gridOffsetZ = 1f;
    public float gridOffsetY = 1f; // Test Höhe

    public int div = 4;

    //Speichern der Informationen in einer Liste
    public List<Vector3> gridList = new List<Vector3>();


    // Bewegen der Formation
    public float maxMoveOffsetX = 5f;

    float curPosX; // Bewegung der Position
    Vector3 startPosition;

    public float speed = 1f; //später noch änderbar
    int direction = -1; //Richtung änderbar zwischen 1 und -1

    void Start()
    {
        startPosition = transform.position; // Start Position des Obj
        curPosX = transform.position.x;

        CreateGrid(); //erstellt Netz damit Enemys wissen wo sie hin sollen
    }

    void Update()
    {
        curPosX += Time.deltaTime * speed * direction; // Bewegt sich nach Link oder Rechts
        if(curPosX >= maxMoveOffsetX)
        {
            direction *= -1;
            curPosX = maxMoveOffsetX;
        }
        else if (curPosX<= -maxMoveOffsetX)
        {
            direction *= -1;
            curPosX = -maxMoveOffsetX;
        }
        transform.position = new Vector3(curPosX, startPosition.y, startPosition.z);
    }

    void OnDrawGizmos()
    {
        gridList.Clear(); //Löschen der Liste

        int num = 0; // Anzahl der Positionen

        for (int i = 0; i < gridSizeBreiteX; i++)
        {
            for (int h = 0; h < gridSizeHöheY; h++)
                {
                for (int j = 0; j < gridSizeLängeZ; j++)
                {
                    //altes Muster berechnung von abstand der Felder im Gitter
                    /* 
                    float x = gridOffsetX * i;
                    float z = gridOffsetZ * j;
                    float y = gridOffsetHöhe * h; // Test Höhe
                    */

                    // float x = (gridOffsetX + gridOffsetX * 2 * (num)); //erstellt ZickZack Muster als Abstand
                    float x = (gridOffsetX + gridOffsetX * 2 * (num / div)) * Mathf.Pow(-1,num%2+1); //ändert den Zahlenwert im oberen Gitter
                    float z = gridOffsetZ * ((num % div) / 2);
                    float y = gridOffsetY * h; // Test Höhe

                    // gewollte position des obj und jetzige Position des obj berechnen
                    Vector3 vec = new Vector3(this.transform.position.x + x, this.transform.position.y + y, this.transform.position.z + z); //erstellt netz aus x,y,z
                // Visualisieren des Gitternetz
                Handles.Label(vec, num.ToString());
                num++;
                    // füllen der Liste mit den Positionen von jeden Feld
                    gridList.Add(vec);
                }
            }
        }
    }
    /*
    void OnDrawGizmos()
    {
        int num = 0;

        CreateGrid();
        foreach(Vector3 pos in gridList )
        {
            Gizmos.drawWireSphere(GetVector(num), 0.1f);
         num++;
        }
    }
    */
    void CreateGrid() //erzeugt Grid auch ohne Gizmos also auch im Build
        {
        gridList.Clear(); //Löschen der Liste

        int num = 0; // Anzahl der Positionen

        for (int i = 0; i<gridSizeBreiteX; i++)
        {
            for (int h = 0; h<gridSizeHöheY; h++)
                {
                for (int j = 0; j<gridSizeLängeZ; j++)
                {
                    //altes Muster berechnung von abstand der Felder im Gitter
                    /* 
                    float x = gridOffsetX * i;
                    float z = gridOffsetZ * j;
                    float y = gridOffsetHöhe * h; // Test Höhe
                    */

                    // float x = (gridOffsetX + gridOffsetX * 2 * (num)); //erstellt ZickZack Muster als Abstand
                   float x = (gridOffsetX + gridOffsetX * 2 * (num / div)) * Mathf.Pow(-1, num % 2 + 1); //ändert den Zahlenwert im oberen Gitter
                   float z = gridOffsetZ * ((num % div) / 2);
                   float y = gridOffsetY * h; // Test Höhe

                   // gewollte position des obj und jetzige Position des obj berechnen anhand der float daten
                   Vector3 vec = new Vector3(x, y, z); 
                                                                                                                          
    
                   num++;
                    // füllen der Liste mit den Positionen von jeden Feld
                    gridList.Add(vec);
                }
            }
        }
    }
    public Vector3 GetVector(int ID)
    {
        return transform.position + gridList[ID];
    }
}