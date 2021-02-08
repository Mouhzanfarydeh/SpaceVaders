using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;

    private float countdown = 10f;

    public int damage;

    bool applyDamage;
    
    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        
    }

    void Update()
    {
        Vector3 dir = target.position - firePoint.position;
        RaycastHit hit;
        Ray laserRay = new Ray(firePoint.transform.position, dir);


        if (target == null)
            //if (useLaser)
            //{
            //    if (lineRenderer.enabled)
            //        lineRenderer.enabled = false;
            //}
            return;

        if (useLaser)
        {
            if(Physics.Raycast(laserRay, out hit))
            {
                if(hit.collider.tag == "Player")
                {
                    Debug.Log("Did Hit!");
                    applyDamage = true;

                    GameObject.Find("wasp").GetComponent<PlayerBehaviour>().TakeDamage(damage);


                }
            }
            Laser();
        }

        countdown -= Time.deltaTime;

    }
    void Laser()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

}
