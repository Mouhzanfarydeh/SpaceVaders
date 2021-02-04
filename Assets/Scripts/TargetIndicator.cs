using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        // Drehe die Kamera jedes Bild, damit sie immer auf das Ziel schaut
        transform.LookAt(Target);

        // Wie oben, aber wenn Sie den Parameter worldUp in diesem Beispiel auf Vector3.left setzen, wird die Kamera auf die Seite gedreht
        transform.LookAt(Target, Vector3.left);
    }
}

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Target.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
    */