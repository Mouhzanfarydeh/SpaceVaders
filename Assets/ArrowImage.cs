using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowImage : MonoBehaviour
{

    public SpriteRenderer unten;
    public SpriteRenderer oben;
    public SpriteRenderer links;
    public SpriteRenderer rechts;

    void start()
    {
        unten = GetComponent<SpriteRenderer>();
        oben = GetComponent<SpriteRenderer>();
        links = GetComponent<SpriteRenderer>();
        rechts = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (transform.position.x > 148)
        {
            links.color = new Color(1, 0, 0, 1);
            Invoke("ChangeColor", 1f);
        }

        if (transform.position.x < -148)
        {
            rechts.color = new Color(1, 0, 0, 1);
            Invoke("ChangeColor", 1f);
        }

        if (transform.position.y > 40)
        {
            unten.color = new Color(1, 0, 0, 1);
            Invoke("ChangeColor", 1f);
        }

        if (transform.position.y < -16)
        {
            oben.color = new Color(1, 0, 0, 1);
            Invoke("ChangeColor", 1f);
        }

      //  CancelInvoke("ChangeColor");
    }

    void ChangeColor()
    {
        links.color = new Color(0, 0, 0, 0);
        rechts.color = new Color(0, 0, 0, 0);
        unten.color = new Color(0, 0, 0, 0);
        oben.color = new Color(0, 0, 0, 0);
    }

}
