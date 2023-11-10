using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterStats character;
    public TextMeshProUGUI atk;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI crit;
    public TextMeshProUGUI dameCrit;


    private void Awake()
    {
        if (GameObject.Find("Player1") != null)
        {
            character = Character1Stats.Instance;
        }
        else
        {
            character = Character2Stats.Instance;
        }
    }
    void Start()
    {
        atk.text = "ATK: " + character.atk.ToString();
        hp.text = "HP: " + character.currentHp.ToString();
        armor.text = "Armor: " + character.armor.ToString();
        crit.text = "CRIT: " + character.crit.ToString() +"%";
        dameCrit.text = "DameCRIT: " + character.crit_dame_percent.ToString() + "%";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacter()
    {
        atk.text = "ATK: " + character.atk.ToString();
        hp.text = "HP: " + character.currentHp.ToString();
        armor.text = "Armor: " + character.armor.ToString();
        crit.text = "CRIT: " + character.crit.ToString() + "%";
        dameCrit.text = "DameCRIT: " + character.crit_dame_percent.ToString() + "%";
    }
}
