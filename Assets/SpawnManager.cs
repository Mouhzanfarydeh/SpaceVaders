using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    public float enemySpawnInterval; //Zeitraum zwischen den spawn der Gegner
    public float waveSpawnInterval; // Zeitraum zwischen den Wellen
    int currentWave; // Zeit wird hochgezählt während der Welle läuft

    [Serializable]
    public class Wave
    {

        //Anzahl der Gegner die in der Welle Spawnen
        public int flyAmount;

     //   public Path path;

        // Landet in
      //  public Formation flyFormation; // für alle kleinen Schiffe
    }

    public List <Wave> waveList = new List<Wave>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
