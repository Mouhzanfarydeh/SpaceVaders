using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;

    public float countdown = 15f;
    public float cooldown = 5f;
    public int damage;
    AudioSource Lasersound;
    //Play the music
    bool Play;
    // public AudioClip Lasersound;

    bool applyDamage;
    
    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        //Fetch the AudioSource from the GameObject
        Lasersound = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        Play = false;

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
            if (lineRenderer.enabled)
                lineRenderer.enabled = false;

            if (countdown <= 0f)
            {
                Play = true;
                if (Play = true)
                {
                    //Play the audio you attach to the AudioSource component
                    Lasersound.Play();
                }
                Laser();
                if (Physics.Raycast(laserRay, out hit))
                {

                    if (hit.collider.tag == "Player")
                    {
                        Debug.Log("Did Hit!");
                        applyDamage = true;

                        GameObject.Find("wasp").GetComponent<PlayerBehaviour>().TakeDamage(damage);

                        countdown = cooldown;
                        Play = false;
                    }
                }
                
            }
        }

        countdown -= Time.deltaTime;

    }
    void Laser()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        //AudioSource.PlayClipAtPoint(Lasersound, transform.position);
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

}
