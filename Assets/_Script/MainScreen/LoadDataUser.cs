using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadDataUser : MonoBehaviour
{
    private void Awake()
    {
        LoadData();
    }



    public void LoadData()
    {
        StartCoroutine(LoadData_Coroutine());
    }

    [System.Obsolete]
    IEnumerator LoadData_Coroutine()
    {
        string urlLogin = $"{ApiConfig.UserUrl}/";
        using (UnityWebRequest request = UnityWebRequest.Get(urlLogin))
        {
            string token =PlayerPrefs.GetString("userToken", "");
            request.SetRequestHeader("Authorization", token);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
                Debug.Log("Lỗi");
            else
            {
                //TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(request.downloadHandler.text);
                
                Debug.Log("Oke");
            }
        }
    }
}
