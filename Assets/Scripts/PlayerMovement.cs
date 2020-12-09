using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{



    //  public CharacterController controller;

    public float speed = 10.0f;  //12f;
    public float gravity = 0;
   // Vector3 velocity;
    public int invert = -1; // Negative 1 for invert, positive 1 for not

    void Update()
    {
        //New Movement 30.11.2020
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, invert * vertical, 0);
        Vector3 finaldirection = new Vector3(horizontal, invert * vertical, 6.0f);


        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finaldirection), Mathf.Deg2Rad * 50.0f);

        // Old Movement (29.11.2020)
        /*
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x  + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    */

}
}
