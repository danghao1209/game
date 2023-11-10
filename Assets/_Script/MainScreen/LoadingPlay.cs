using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPlay : MonoBehaviour
{
    public SliderBar slider;
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously(2));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            slider.UpdateProgress(Mathf.RoundToInt(progressValue));
            slider.OnSliderChanged(Mathf.RoundToInt(progressValue));
            yield return operation;
        }
    }
}
