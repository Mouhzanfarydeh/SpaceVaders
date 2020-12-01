using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
/*
public class NewBehaviourScript : MonoBehaviour
{

    // leider verbuggt

  public void QuickSpin(int dir)
  {
      if (Input.GetKeyDown('q'))
      {
          transform.position = playerModel.DOLocalRotate(new Vector3(playerModel.localEulerAngles.x, playerModel.localEulerAngles.y, 360 * -dir), .6f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
      }
  }
}

public float barrelRollDuration = 1.0f;

public bool inBarrelRoll = false;

private float movementAxis;

// Update is called once per frame
void Update()
{

    if (!inBarrelRoll)
    {

        (Input.GetKeyUp(KeyCode.F))
         {

            StartCoroutine("BarrelRoll");

        }

    }
}

IEnumerator BarrelRoll()
{
    inBarrelRoll = true;

    float t = 0.0f;

    Vector3 initialRotation = transform.localRotation.eulerAngles;

    Vector3 goalRotation = initialRotation;

    goalRotation.z += 180.0f;

    Vector3 currentRotation = initialRotation;

    while (t < barrelRollDuration / 2.0f)
    {
        currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));

        transform.localRotation = Quaternion.Euler(currentRotation);

        t += Time.deltaTime;

        yield return null;
    }

    t = 0;




    initialRotation = transform.localRotation.eulerAngles;

    goalRotation = initialRotation;

    goalRotation.z += 180.0f;

    while (t < barrelRollDuration / 2.0f)
    {
        currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));

        transform.localRotation = Quaternion.Euler(currentRotation);

        t += Time.deltaTime;

        yield return null;
    }


    inBarrelRoll = false;

    ResetRotation();

}

void ResetRotation()
{
    transform.localRotation = Quaternion.identity;

}
}
*/