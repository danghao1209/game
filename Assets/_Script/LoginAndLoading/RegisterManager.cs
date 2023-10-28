using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    // Start is called before the first frame update

    private TMP_InputField usernameRegister;
    private TMP_InputField passwordRegister;
    private TMP_InputField rePasswordRegister;

    public GameObject MissingRegister;
    public GameObject SuccessRegister;
    public GameObject RegisterFail;
    public GameObject CheckPassRegister;
    public GameObject LoginForm;
    public GameObject RegisterForm;


    [SerializeField]
    void Start()
    {

        usernameRegister = GameObject.Find("AccountRegister").GetComponent<TMP_InputField>();
        passwordRegister = GameObject.Find("PasswordRegister").GetComponent<TMP_InputField>();
        rePasswordRegister = GameObject.Find("RePasswordRegister").GetComponent<TMP_InputField>();



        GameObject.Find("RegisterButton").GetComponent<Button>().onClick.AddListener(Register);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register()
    {
        StartCoroutine(Register_Coroutine());
    }

    IEnumerator Register_Coroutine()
    {
        string username = usernameRegister.text;
        string password = passwordRegister.text;
        string rePassword = rePasswordRegister.text;

        if(username =="" || password == "" || rePassword == "")
        {
            MissingRegister.SetActive(true);
            RegisterFail.SetActive(false);
            SuccessRegister.SetActive(false);
            CheckPassRegister.SetActive(false);
        }
        else if (password != rePassword)
        {
            CheckPassRegister.SetActive(true);
            MissingRegister.SetActive(false);
            RegisterFail.SetActive(false);
            SuccessRegister.SetActive(false);
        }
        else
        {
            string urlLogin = $"{ApiConfig.AuthUrl}/signup";
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("rePassword", rePassword);

            using (UnityWebRequest request = UnityWebRequest.Post(urlLogin, form))
            {
                yield return request.SendWebRequest();
                if (request.isHttpError || request.isNetworkError)
                {
                    RegisterFail.SetActive(true);
                    CheckPassRegister.SetActive(false);
                    MissingRegister.SetActive(false);
                    SuccessRegister.SetActive(false);
                }    
                else
                {
                    TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(request.downloadHandler.text);
                    GameObject.Find("RegisterButton").GetComponent<Button>().onClick.AddListener(Register);
                    SuccessRegister.SetActive(true);
                    RegisterFail.SetActive(false);
                    CheckPassRegister.SetActive(false);
                    MissingRegister.SetActive(false);
                    yield return new WaitForSeconds(2.0f);
                    LoginForm.SetActive(true);
                    RegisterForm.SetActive(false);
                    usernameRegister.text = "";
                    passwordRegister.text = "";
                    rePasswordRegister.text = "";
                }
            }
        }


        
    }
}

