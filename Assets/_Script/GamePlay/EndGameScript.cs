using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI coin;
    public TextMeshProUGUI boss;
    public TextMeshProUGUI enemy;

    // Start is called before the first frame update
    void Start()
    {
        Timer gameManager = FindObjectOfType<Timer>();
        if(gameManager.remainingTime == 0)
        {
            title.text = "Win";
        }
        else
        {
            title.text = "Lose";
        }
        coin.text = GamePlayManager.Instance.coin.ToString();
        boss.text = UpGradeInGamePlay.Instance.BossCountEnd().ToString();
        enemy.text = UpGradeInGamePlay.Instance.EnemyCountEnd().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EndGameAndAddCoin()
    {
        StartCoroutine(AddCoin(GamePlayManager.Instance.coin));
    }

    IEnumerator AddCoin(int coin)
    {


        string urlLogin = $"{ApiConfig.UserUrl}/addcoin";
        WWWForm form = new WWWForm();
        form.AddField("coin", coin);
        using (UnityWebRequest request = UnityWebRequest.Post(urlLogin, form))
        {
            string token = PlayerPrefs.GetString("userToken", "");
            request.SetRequestHeader("Authorization", token);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {

                AsyncOperation operation = SceneManager.LoadSceneAsync(1);

                yield return operation;
            }
            else
            {

                LoadDataUser.Instance.playerData.coin += coin;
                AsyncOperation operation = SceneManager.LoadSceneAsync(1);
                yield return operation;

            }
        }
    }
}
