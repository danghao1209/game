using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    // Tạo một instance duy nhất của lớp User
    private static User _instance;

    public string id;
    public string username;
    private string password;
    public int score;
    public int gem;
    public bool isLoggedIn;

    private void Awake()
    {
        // Đảm bảo rằng chỉ có một instance duy nhất của User
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Phương thức để truy cập instance của User từ bất kỳ đâu
    public static User Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject userObject = new GameObject("User");
                _instance = userObject.AddComponent<User>();
            }
            return _instance;
        }
    }
}