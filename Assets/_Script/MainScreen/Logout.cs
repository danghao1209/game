using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logout : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("LogOutBtn").GetComponent<Button>().onClick.AddListener(LogoutFunc);
    }
    // Start is called before the first frame update
    public void LogoutFunc()
    {
        StartCoroutine(Logout_Coroutine());
    }
    IEnumerator Logout_Coroutine()
    {

        PlayerPrefs.SetString("userToken", "");

        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        yield return operation;
    }
}
