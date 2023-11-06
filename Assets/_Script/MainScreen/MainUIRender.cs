using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIRender : MonoBehaviour
{
    

    public Text nameText;
    public Text upgradeText;
    public Text gemText;
    public Text coinText;

    // Start is called before the first frame update
    private void Start()
    {
        PlayerData playerData = LoadDataUser.Instance.playerData;
        nameText.text = playerData.username;
        upgradeText.text = "Upgrade: " + playerData.upgrade.ToString();
        gemText.text = playerData.gem.ToString();
        coinText.text = playerData.coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
