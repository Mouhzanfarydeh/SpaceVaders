using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextScene : MonoBehaviour
{
    public float delay = 5;
    public string NewLevel = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel(delay));
    }

    IEnumerator LoadLevel(float delay)

    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }

}
