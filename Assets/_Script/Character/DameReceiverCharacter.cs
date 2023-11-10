using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameReceiverCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    protected CharacterStats characterStats;
    public GameObject endUI;
    void Start()
    {
        if (GameObject.Find("Player1") != null)
        {
            
            characterStats = Character1Stats.Instance;
        }
        else
        {
            Debug.LogWarning("player2");
            characterStats = Character2Stats.Instance;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual void Receive(int damage)
    {
        Debug.LogWarning("Dame nhân " + damage.ToString());

        int dameAfterArmor = damage - characterStats.armor;
        if (dameAfterArmor < 0) { dameAfterArmor = 0; }
        if (characterStats != null)
        {
            // Đảm bảo damage không âm
            if (damage < 0)
            {
                damage = 0;
            }

            // Trừ damage và sự kháng của nhân vật
            characterStats.currentHp -= (dameAfterArmor);


            // Đảm bảo currentHp không âm
            if (characterStats.currentHp < 0)
            {
                characterStats.currentHp = 0;
                Time.timeScale = 0;
                endUI.SetActive(true);
            }


            HpBarManager.Instance.UpdateHealthBar(characterStats.currentHp, characterStats.maxHealth);
        }
    }
}