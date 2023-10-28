using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    
    public Button settingButton;
    public Button continueButton;
    public Button closeButton;
    public GameObject settingUI;
    void Start()
    {
        settingButton.onClick.AddListener(PauseGame);
        continueButton.onClick.AddListener(ResumeGame);
        closeButton.onClick.AddListener(ResumeGame);
    }

    void PauseGame()
    {
        Time.timeScale = 0; // Tạm dừng trò chơi

        // Hiển thị màn hình cài đặt ở đây
        //settingUI.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Tiếp tục trò chơi

        // Ẩn màn hình cài đặt ở đây
        //settingUI.SetActive(false);
    }
}
