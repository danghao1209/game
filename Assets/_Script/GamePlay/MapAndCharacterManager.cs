using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAndCharacterManager : MonoBehaviour
{
    public GameObject character;
    public GameObject character1;
    public GameObject character2;
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;

    void Awake()
    {
        if (SelectCharacterAndMapManager.Instance.characterNumber == 1)
        {
            character1.SetActive(true);
            character2.SetActive(false);
            character.SetActive(true);
        }
        else
        {
            character1.SetActive(false);
            character2.SetActive(true);
            character.SetActive(true);
        }

        if(SelectCharacterAndMapManager.Instance.mapNumber == 1)
        {
            map1.SetActive(true);
            map2.SetActive(false);
            map3.SetActive(false);
        }
        else if (SelectCharacterAndMapManager.Instance.mapNumber == 2)
        {
            map1.SetActive(false);
            map2.SetActive(true);
            map3.SetActive(false);
        }
        else
        {
            map1.SetActive(false);
            map2.SetActive(false);
            map3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
