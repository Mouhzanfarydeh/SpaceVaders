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
    public GameObject Enemy2Prefab;
    public GameObject BossPrefab;

    [Header("Formation")]
    //Landet in
    public Formation VirusFormation; // für alle Virus-schiffe
    public Formation Enemy2Formation;
    public Formation BossFormation;


    [System.Serializable]
    public class Wave
    {

    public int VirusAmount; //Anzahl der Gegner die in der Welle Spawnen
    public int Enemy2Amount;
    public int BossAmount;

        
     // public Path path; //Benutzen von 1 Weg nicht änderbar

    public GameObject[] pathPrefabs; //Benutzen von Prefabs zum benutzen der Wege --------------------------- Neue Formation

    }
   [Header("Waves")]
   public List <Wave> waveList = new List<Wave>(); //Liste der Gegner

   List <Path> activePathList = new List<Path>(); //--------------------------------- Neue Formation

    [HideInInspector]
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    bool spawnComplete;

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
            if(currentWave == waveList.Count-1)
            {
                spawnComplete = true;
            }
            */

            //Paths neue Formation
            for (int i = 0; i < waveList[currentWave].pathPrefabs.Length; i++) //spawning pathes
            {
                GameObject newPathObj = Instantiate(waveList[currentWave].pathPrefabs[i], transform.position, Quaternion.identity) as GameObject;
                Path newPath = newPathObj.GetComponent<Path>();
                activePathList.Add(newPath);



            }
            yield return new WaitForSeconds(enemySpawnInterval);
            // Spawn der Virus-Schiffe
            for (int i = 0; i < waveList[currentWave].VirusAmount; i++)
            {
                GameObject newVirus = Instantiate(VirusPrefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                Enemybehavior VirusBehavior = newVirus.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                //neue Spawn Formation
                VirusBehavior.SpawnSetup(activePathList[ZickZack()], VirusID, VirusFormation); //einbringung der Daten vom Enemybehavior (pathToFollow = path, enemyID = ID, formation = _formation
                VirusID++;

                //alte Spawn Formation
                //VirusBehavior.SpawnSetup(waveList[currentWave].path, VirusID, VirusFormation);
                

                spawnedEnemies.Add(newVirus);

                //weitergeben an Game Manager
                GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }

            // Spawn der Enemy2 Schiffe
            
            for (int i = 0; i < waveList[currentWave].Enemy2Amount; i++)
            {
                GameObject newEnemy2 = Instantiate(Enemy2Prefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                Enemybehavior Enemy2Behavior = newEnemy2.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                Enemy2Behavior.SpawnSetup(activePathList[ZickZack()], Enemy2ID, Enemy2Formation); //einbringung der Daten vom Enemybehavior (pathToFollow = path, enemyID = ID, formation = _formation
                Enemy2ID++;

                //spawnedEnemies.Add(newEnemy2);

                //weitergeben an Game Manager
                //GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }
                       // for (int i = 0; i < waveList[currentWave].Enemy2Amount; i++) ----------------- Weiß nicht mehr wozu das war


            // Spawn der Boss Schiffe
             for (int i = 0; i < waveList[currentWave].BossAmount; i++)
             {
                GameObject newBoss = Instantiate(BossPrefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                Enemybehavior BossBehavior = newBoss.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                BossBehavior.SpawnSetup(activePathList[ZickZack()], BossID, BossFormation); //einbringung der Daten vom Enemybehavior (pathToFollow = path, enemyID = ID, formation = _formation
                BossID++;

                //spawnedEnemies.Add(newBoss);

                //weitergeben an Game Manager
                //GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
             }


            

            yield return new WaitForSeconds(waveSpawnInterval);
            currentWave++; //Startet nächste Welle

            foreach(Path p in activePathList) //löschen des benutzten Weg
            {
                Destroy(p.gameObject);
            }
            activePathList.Clear();
        }
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnWaves());
        CancelInvoke("StartSpawn"); //fürs debuggen
    }
    //------------------------------------
    
    int ZickZack()
    {
        return (VirusID + BossID + Enemy2ID) % activePathList.Count;
    }

    void OnValidate() //wird aktiviert wann immer eine nummer im Inspector verändert wird
                      // zählt alle Virus-Schiffe im Spiel zusammen
    {
        int curVirusAmount = 0;
        for (int i = 0; i < waveList.Count; i++)
        {
            curVirusAmount += waveList[i].VirusAmount;
        }
       
        if (curVirusAmount > 35)                                 //wenn mehr als 35 Feinde im Spiel sind entsteht Fehlermeldung
        {
            Debug.LogError("<color=red>Error!!</color> Your Virus amount is to high!" + curVirusAmount + "/ 20");
        }
      else
      { 
        Debug.Log("Current Total Virus: " + curVirusAmount);
      }
    }
    
    /*
    void ReportToGameManager()
    {
           if(spawnedEnemies.Count == 0 && spawnComplete)
       // if (spawnComplete)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.instance.WinCondition();
        }
    }

    public void UpdateSpawnedEnemies(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);

        ReportToGameManager();
    }
    */
}
