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
    public bool loadDataSucess = false;
    public bool loadDataPetSucess = false;
    public bool loadDataUpgradeSucess = false;

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

    public void LoadLevel1()
    {
        StartCoroutine(LoadAsynchronously(1));
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
                    yield return new WaitForSeconds(3); // Tạm dừng courotin trong 5 giây.
                                                        
                    while (!loginSuccess)// Sử dụng vòng lặp while để đợi cho đến khi loginSuccess trở thành true
                    {
                        
                        yield return null; // Tạm dừng coroutine để tránh chiếm CPU quá nhiều.
                    }
                    loginScreen.SetActive(false);
                    // Sau khi loginSuccess trở thành true, tiếp tục thực thi coroutine
                    

                }
            }


            if (i == 25)
            {
                loginScreen.SetActive(false);
                LoadDataUser loadDataUser = LoadDataUser.Instance;
                loadDataUser.LoadData();
                while (!loadDataSucess)// Sử dụng vòng lặp while để đợi cho đến khi loginSuccess trở thành true
                {
                    yield return null; // Tạm dừng coroutine để tránh chiếm CPU quá nhiều.
                }
            }

            if (i == 45)
            {
                loginScreen.SetActive(false);
                PetManager petManager = PetManager.Instance;
                petManager.LoadDataPet();
                while (!loadDataPetSucess)// Sử dụng vòng lặp while để đợi cho đến khi loginSuccess trở thành true
                {
                    yield return null; // Tạm dừng coroutine để tránh chiếm CPU quá nhiều.
                }
            }

            if (i == 80)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
                yield return operation; // Tạm dừng coroutine cho đến khi màn hình được tải xong.
            }
        }
    }


}