using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float RotationSpeed = .001f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0f, 0f, RotationSpeed);
    }
}
