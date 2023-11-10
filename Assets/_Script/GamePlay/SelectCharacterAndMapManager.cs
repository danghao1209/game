using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterAndMapManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static SelectCharacterAndMapManager instance;
    public GameObject Character1Bg;
    public GameObject Character2Bg;

    public GameObject panelPickMap;

    public Text textMap;

    public int characterNumber;
    public int mapNumber;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        characterNumber = 1;
        mapNumber = 1;
        textMap.text = "planet";
    }

    void Start()
    {
        if(characterNumber == 1)
        {
            Character1Bg.SetActive(true);
            Character2Bg.SetActive(false);

        }
        if (characterNumber == 2)
        {
            Character1Bg.SetActive(false);
            Character2Bg.SetActive(true);

        }
    }

    
    public static SelectCharacterAndMapManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SelectCharacterAndMapManager>();
            }
            return instance;
        }
    }

    public void SelectCharacter1()
    {
        characterNumber = 1;
        Character1Bg.SetActive(true);
        Character2Bg.SetActive(false);
    }

    public void SelectCharacter2()
    {
        characterNumber = 2;
        Character1Bg.SetActive(false);
        Character2Bg.SetActive(true);
    }

    public void SetMap1() 
    {

        mapNumber = 1;
        textMap.text = "planet";
        panelPickMap.SetActive(false);
    }

    public void SetMap2()
    {

        mapNumber = 2;
        textMap.text = "ice";
        panelPickMap.SetActive(false);


    }

    public void SetMap3()
    {

        mapNumber = 3;
        textMap.text = "laval";
        panelPickMap.SetActive(false);

    }
}
