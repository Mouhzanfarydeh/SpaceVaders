using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
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
