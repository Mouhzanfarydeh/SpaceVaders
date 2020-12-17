using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    [Header("Intervals")] //Fügt Überschrift ein
    public float enemySpawnInterval; //Zeitraum zwischen den spawn der Gegner
    public float waveSpawnInterval; // Zeitraum zwischen den Wellen
    int currentWave; // Zeit wird hochgezählt während der Welle läuft

   int VirusID = 0;
   int Enemy2ID = 0;
   int BossID = 0;

    [Header("Prefabs")]
    public GameObject VirusPrefab; //hier Einheit einsetzten
    public GameObject Enemy2;
    public GameObject BossPrefab;

    [Header("Formation")]
    //Landet in
    public Formation VirusFormation; // für alle Virus-schiffe
 // public Formation Enemy2Formation;
 // public Formation BossFormation;


    [System.Serializable]
    public class Wave
    {

    public int VirusAmount; //Anzahl der Gegner die in der Welle Spawnen
 // public int Enemy2Amount;
 // public int BossAmount;

        
    public Path path; //Benutzen von 1 Prefab

  //  public GameObject[] pathPrefabs; //Benutzen von Prefabs zum benutzen der Wege ---------------------------

    }
   [Header("Waves")]
   public List <Wave> waveList = new List<Wave>(); //Liste der Gegner

  //  List <Path> activePathList = new List<Path>(); ---------------------------------


    void Start()
    {
        //Warten bevor starten des Spawnens beginnt
        Invoke("StartSpawn", 3f); //Wartet 3 Sekunden
    }
    

    IEnumerator SpawnWaves() // erstellen eine routine
    {
        while(currentWave < waveList.Count) //Prüfung wie viele Wellen noch bevorsthenen und bei welcher wir gerade sind
        {
            /*
            for (int i = 0; i < waveList[currentWave].pathPrefabs.Length; i++) //spawning pathes
            {
                GameObject newPathObj = Instantiate(waveList[currentWave].pathPrefabs[i], transform.position, Quaternion.identity) as GameObject;
                Path newPath = newPathObj.GetComponent<Path>();
                activePathList.Add(newPath);
            }
            */
            // Spawn der Virus-Schiffe
            for (int i = 0; i < waveList[currentWave].VirusAmount; i++)
            {
                GameObject newVirus = Instantiate(VirusPrefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                Enemybehavior VirusBehavior = newVirus.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                //neue Spawn Formation
                //   VirusBehavior.SpawnSetup(activePathList[ZickZack()], VirusID, VirusFormation); //einbringung der Daten vom Enemybehavior (pathToFollow = path, enemyID = ID, formation = _formation

                //alte Spawn Formation
                VirusBehavior.SpawnSetup(waveList[currentWave].path, VirusID, VirusFormation);
                VirusID++;

                //weitergeben an Game Manager
             //   spawnedEnemies.Add(newVirus);  ----------- noch unvollendet
                GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }

            // Spawn der Enemy2 Schiffe
            /*
            for (int i = 0; i < waveList[currentWave].Enemy2Amount; i++)
            {
                GameObject newEnemy2 = Instantiate(Enemy2Prefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                Enemybehavior Enemy2Behavior = newEnemy2.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                Enemy2Behavior.SpawnSetup(activePathList[ZickZack()], Enemy2ID, Enemy2Formation); //einbringung der Daten vom Enemybehavior (pathToFollow = path, enemyID = ID, formation = _formation
                Enemy2ID++;

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }
                        for (int i = 0; i < waveList[currentWave].Enemy2Amount; i++)


            // Spawn der Boss Schiffe
             for (int i = 0; i < waveList[currentWave].BossAmount; i++)
            {
                GameObject newBoss = Instantiate(BossPrefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                Enemybehavior BossBehavior = newBoss.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                BossBehavior.SpawnSetup(activePathList[ZickZack()], BossID, BossFormation); //einbringung der Daten vom Enemybehavior (pathToFollow = path, enemyID = ID, formation = _formation
                BossID++;

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }


            */

            yield return new WaitForSeconds(waveSpawnInterval);
            currentWave++; //Startet nächste Welle
        }
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnWaves());
        CancelInvoke("StartSpawn"); //fürs debuggen
    }
    /*------------------------------------
    /*
    int ZickZack()
    {
        return (VirusID + BossID + Enemy2ID) % activePathList.Count;
    }
    /*





    /*
    //Virus
    spawned Enemies.Add(newVirus);
    //weitergeben an Game Manager
    GameManager.instance.AddEnemy();

    //Enemy2
    spawned Enemies.Add(newEnemy2);
    //weitergeben an Game Manager
    GameManager.instance.AddEnemy();

    //Boss
    spawned Enemies.Add(newBoss);
    //weitergeben an Game Manager
    GameManager.instance.AddEnemy();
    */

    // Update is called once per frame

}
