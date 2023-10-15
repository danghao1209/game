using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject LoadingScreen;
    public SliderBar sliderBar;
    public GameObject loginScreen ;
    private bool loginSuccess = false;
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
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            sliderBar.UpdateProgress(Mathf.FloorToInt(progress)); 

            yield return null;
        }
    }

    IEnumerator LoadAsynchronously2(int sceneIndex)
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
                    if (loginSuccess)
                    {
                        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
                        yield return operation; // Tạm dừng courotin cho đến khi màn hình được tải xong.
                        // Tiếp tục thực thi courotin.
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi cho người dùng.
                    }
                    
                }
                else
                {
                    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
                    yield return operation; // Tạm dừng courotin cho đến khi màn hình được tải xong.
                }
            }
        }
    }



    //float progress = Mathf.Clamp01(operation.progress / 0.9f);

    //sliderBar.UpdateProgress(Mathf.FloorToInt(progress));

    //if (Mathf.FloorToInt(progress * 100) >= 5)
    //{
    //    // Kiểm tra token
    //    string userToken = PlayerPrefs.GetString("userToken", null);
    //    if (userToken == null)
    //    {
    //        // Token không tồn tại, hiển thị màn hình đăng nhập và dừng quá trình loading
    //        loginScreen.SetActive(true);
    //        // Đợi đến khi người dùng đăng nhập
    //        while (!loginSuccess)
    //        {
    //            yield return null;
    //        }
    //        // Sau khi đăng nhập thành công, kiểm tra lại token
    //        userToken = PlayerPrefs.GetString("userToken", null);
    //        if (userToken == null)
    //        {
    //            // Đăng nhập không thành công sau khi dừng quá trình loading
    //            // Thực hiện các xử lý khác
    //            yield break;
    //        }
    //        // Token tồn tại, tiếp tục loading
    //    }
    //    else
    //    {
    //       
    //    }
    //}
    //yield return null;
    IEnumerator LoadAsynchronously3(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            sliderBar.UpdateProgress(Mathf.FloorToInt(progress));

            if (Mathf.FloorToInt(progress * 100) >= 10)
            {
                if (!loginSuccess)
                {
                    // Token không tồn tại, hiển thị màn hình đăng nhập và dừng quá trình loading
                    // Hiển thị màn hình đăng nhập
                    loginScreen.SetActive(true);
                    // Dừng quá trình loading
                    yield break;
                }
            }

            yield return null;
        }
    }
}