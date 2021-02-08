using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCanon : MonoBehaviour
{
    public Transform turretBase;
    public Transform cannonParent;
    public Transform[] lasers;
    public float laserRotationSpeed = 1.0f;
    public float laserShotDelay = 5.0f;
    public float laserChargeTime = 2.0f;
    public float laserSpeed = 1.0f;
    public float laserDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChargeLaser", laserShotDelay);
    }

    void ChargeLaser()
    {
        foreach(Transform laser in lasers)
        {
            laser.gameObject.SetActive(true);
        }
        Debug.Log("LASER LÄDT AUF");
        Invoke ("FireLaser", laserChargeTime);
    }

    void FireLaser()
    {
        StartCoroutine("LaserCoroutine");
    }

    IEnumerator LaserCoroutine()
    {
        float t = 0.0f;
        while (t < laserDuration)
        {
            foreach(Transform laser in lasers)
            {
                Vector3 newScale = laser.localScale;
                newScale.z += laserSpeed * Time.deltaTime;
                laser.localScale = newScale;
            }
            t += Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Zielen auf Spieler
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        cannonParent.transform.rotation = Quaternion.LookRotation(player.transform.position - cannonParent.position);
    }
}
