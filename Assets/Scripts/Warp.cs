using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    bool Jump = false;

    void Warpjump()
    {
        if (Jump == true)
        {
            gameObject.SetActive(true);
            //Instantiate(WarpEffect, transform.position, Quaternion.identity);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }



    /*
    public GameObject WarpEffect;
    public static bool Jump;

    // Start is called before the first frame update
    
    void Start()
    {
        Jump = false;
       // gameObject.SetActive(false);
    }
    

    void Update()
    {
        if (Jump == true)
        {
            gameObject.SetActive(true);
            //Instantiate(WarpEffect, transform.position, Quaternion.identity);
        }
        else
        {
            gameObject.SetActive(false);
        }
        /*
        //public void WarpJump()
        //{
         if (WarpEffect != null) //bedeutet wenn der Slot nicht mit einen Prefab gefüllt ist, passiert nichts
            //{
         Instantiate(WarpEffect, transform.position, Quaternion.identity);
            //}
       // }
       
    }
*/
}
