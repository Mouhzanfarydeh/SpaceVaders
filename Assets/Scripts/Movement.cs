using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float movementSpeed = 10f;
    void Update()
    {
        transform.position += new Vector3(0, 0, movementSpeed * Time.deltaTime);
    }
}