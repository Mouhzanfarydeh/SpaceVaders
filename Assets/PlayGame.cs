using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButton(0)) //der erste klick der Maus
        {
            SceneManager.LoadScene("Stage1");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}
