using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladebildschirm : MonoBehaviour { 

    public GameObject Laden;

    AsyncOperation async;

    public void Loadperbutton()

    {
        StartCoroutine(LoadingScene());
    }

    IEnumerator LoadingScene()
    {
        Laden.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        yield return null;
    }
}