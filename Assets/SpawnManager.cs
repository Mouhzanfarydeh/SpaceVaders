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

    /*
    void Start()
    {
        //Aufrufen des Start Punkt
        Invoke("StartSpawn", 3f);
    }
    //FLYs
    spawned Enemies.Add(newFly);
    //weitergeben an Game Manager
    GameManager.instance.AddEnemy();

    //Wasps
    spawned Enemies.Add(newWasp);
    //weitergeben an Game Manager
    GameManager.instance.AddEnemy();

    //Boss
    spawned Enemies.Add(newBoss);
    //weitergeben an Game Manager
    GameManager.instance.AddEnemy();
    */



    // Update is called once per frame
    void Update()
    {
        
    }
}
