using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{

    public GameObject LoadingScreen;
    public SliderBar sliderBar;
    public GameObject loginScreen ;
    public bool loginSuccess = false;

    private static LoadingManager _instance;
    public static LoadingManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    public void Start()
    {
        LoadLevel(1);
    }
    public void LoadLevel(int sceneIndex)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        for (int i = 0; i < 100; i++)
        {
            sliderBar.UpdateProgress(Mathf.FloorToInt(i));

            if (i == 5)
            {
                string userToken = PlayerPrefs.GetString("userToken", "");
                if (userToken.ToString() == "")
                {
                    loginScreen.SetActive(true);
                    yield return new WaitForSeconds(5); // Tạm dừng courotin trong 5 giây.
                                                        
                    while (!loginSuccess)// Sử dụng vòng lặp while để đợi cho đến khi loginSuccess trở thành true
                    {
                        yield return null; // Tạm dừng coroutine để tránh chiếm CPU quá nhiều.
                    }

                    // Sau khi loginSuccess trở thành true, tiếp tục thực thi coroutine
                    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
                    yield return operation; // Tạm dừng coroutine cho đến khi màn hình được tải xong.

                }
                else
                {
                    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
                    yield return operation; // Tạm dừng courotin cho đến khi màn hình được tải xong.
                }
            }
        }
    }


    

}