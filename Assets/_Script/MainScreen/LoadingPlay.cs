using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPlay : MonoBehaviour
{
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously(2));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            yield return operation;
        }
    }
}
