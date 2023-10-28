using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class LoginManager : MonoBehaviour
{
    private TMP_InputField usernameLogin;
    private TMP_InputField passwordLogin;

    void Start()
    {
        usernameLogin = GameObject.Find("AccountLogin").GetComponent<TMP_InputField>();
        passwordLogin = GameObject.Find("PasswordLogin").GetComponent<TMP_InputField>();
        GameObject.Find("LoginButton").GetComponent<Button>().onClick.AddListener(Login);
    }

    public void Login()
    {
        StartCoroutine(Login_Coroutine());
    }

    [System.Obsolete]
    IEnumerator Login_Coroutine()
    {
        string urlLogin = $"{ApiConfig.AuthUrl}/signin";
        WWWForm form = new WWWForm();
        form.AddField("username", usernameLogin.text);
        form.AddField("password", passwordLogin.text);
        using (UnityWebRequest request = UnityWebRequest.Post(urlLogin, form))
        {
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
                Debug.Log("Lỗi");
            else
            {
                TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(request.downloadHandler.text);
                string token = tokenResponse.token;
                PlayerPrefs.SetString("userToken", token);
                LoadingManager.Instance.loginSuccess = true;
                Debug.Log(PlayerPrefs.GetString("userToken", ""));
            }    
        }
    }

    
}

[System.Serializable]
public class TokenResponse
{
    public string token;
}
