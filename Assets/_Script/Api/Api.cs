using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Api : MonoBehaviour
{
    private static string baseApi = "" ;
    private static Api _instance;

    public static Api Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Api>();
            }
            return _instance;
        }
    }

    public delegate void OnAPICallback(string result);

    [System.Obsolete]
    public void GetRequest(string url, OnAPICallback callback)
    {
        StartCoroutine(SendGETRequest(url, callback));
    }

    [System.Obsolete]
    public void PostRequest(string url, string data, OnAPICallback callback)
    {
        StartCoroutine(SendPOSTRequest(url, data, callback));
    }

    [System.Obsolete]
    private IEnumerator SendGETRequest(string url, OnAPICallback callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Error: " + www.error);
            callback(null);
        }
        else
        {
            callback(www.downloadHandler.text);
        }
    }

    [System.Obsolete]
    private IEnumerator SendPOSTRequest(string url, string data, OnAPICallback callback)
    {
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(data);

        UnityWebRequest www = new UnityWebRequest(url, "POST");
        www.uploadHandler = new UploadHandlerRaw(postData);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Error: " + www.error);
            callback(null);
        }
        else
        {
            callback(www.downloadHandler.text);
        }
    }
}
