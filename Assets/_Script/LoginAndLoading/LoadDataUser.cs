using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDataUser : MonoBehaviour
{
    public static LoadDataUser Instance { get; private set; }
    public PlayerData playerData { get; private set; }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Nếu đã có một thể hiện khác, hủy bỏ thể hiện hiện tại
            Destroy(gameObject);
            return;
        }
        // Không bị hủy bỏ khi chuyển giữa các cảnh
        DontDestroyOnLoad(gameObject);
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
            {
                Debug.Log("Lỗi");
                StartCoroutine(Logout_Coroutine());
                Destroy(gameObject);
                
            }    
            else
            {
                playerData = JsonConvert.DeserializeObject<PlayerData>(request.downloadHandler.text);
                Debug.Log(playerData.gem);
                if (LoadingManager.Instance != null)
                {
                    LoadingManager.Instance.loadDataSucess = true;
                }
            }
        }
    }
    IEnumerator Logout_Coroutine()
    {

        PlayerPrefs.SetString("userToken", "");

        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        yield return operation;
    }
}

public class PlayerData
{
    public string username { get; set; }
    public string password { get; set; }
    public int coin { get; set; }
    public int gem { get; set; }
    public int upgrade { get; set; }
    public string avatar { get; set; }
    public int pet { get; set; }
    public int character { get; set; }
    public bool isActive { get; set; }
}
