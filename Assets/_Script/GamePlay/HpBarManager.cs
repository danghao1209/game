using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject character1;
    [SerializeField] private GameObject character2;
    CharacterStats character;

    private static HpBarManager instance;


    private Quaternion originalRotation;

    public static HpBarManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HpBarManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }


        if (character1 != null)
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
        originalRotation = transform.localRotation;
        UpdateHealthBar(character.currentHp, character.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = originalRotation;
    }


    public void UpdateHealthBar(int currentValue, int maxValue)
    {
        slider.value = (float)currentValue / (float)maxValue;
    }
}
