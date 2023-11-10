using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Linq;

public class Pet
{
    public string _id { get; set; }
    public string name { get; set; }
    public int star { get; set; }
    public int atk { get; set; }
    public float cooldown { get; set; }
    public int atkBuff { get; set; }
    public int critBuff { get; set; }
    public int speedRunBuff { get; set; }
    public int speedAttachBuff { get; set; }
    public int hpBuff { get; set; }
    public int dameCritBuff { get; set; }
    public int armorBuff { get; set; }
}

public class PetManager : MonoBehaviour
{
    public static PetManager Instance { get; private set; }
    public List<Pet> pets { get; set; }

    public Pet water;
    public Pet fire;
    public Pet acid;
    public Pet wind;
    public Pet lighting;
    public Pet dark;

    private void Awake()
    {
        // Đảm bảo rằng chỉ có một thể hiện duy nhất của PetManager
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

    [System.Obsolete]
    private void Start()
    {
        // Đọc dữ liệu JSON từ tệp TextAsset trong Unity
    }

    [System.Obsolete]
    public void LoadDataPet()
    {
        StartCoroutine(LoadDataPet_Coroutine());
    }



    [System.Obsolete]
    IEnumerator LoadDataPet_Coroutine()
    {
        string urlLogin = $"{ApiConfig.PetUrl}/all";
        using (UnityWebRequest request = UnityWebRequest.Get(urlLogin))
        {
            string token = PlayerPrefs.GetString("userToken", "");
            request.SetRequestHeader("Authorization", token);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
                Debug.Log("Lỗi");
            else
            {
                //TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(request.downloadHandler.text);
                pets = JsonConvert.DeserializeObject<List<Pet>>(request.downloadHandler.text);
                Debug.Log("pet ok");
                water = GetPetByName("water");
                fire = GetPetByName("fire");
                acid = GetPetByName("acid");
                wind = GetPetByName("wind");
                lighting = GetPetByName("lighting");
                dark = GetPetByName("dark");
                LoadingManager.Instance.loadDataPetSucess = true;
                yield return null;
            }
        }
    }
    private Pet GetPetByName(string petName)
    {
        for (int i = 0; i < pets.Count; i++)
        {
            if (pets[i].name == petName)
            {
                return pets[i];
            }
        }
        return null; // Trả về null nếu không tìm thấy pet
    }
}
