using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePetManager : MonoBehaviour
{
    private List<string> danhSachPet = new List<string>();
    private List<string> danhSachPetDaNangCap = new List<string>();
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject lighting;
    [SerializeField] private GameObject acid;
    [SerializeField] private GameObject wind;


    private static UpdatePetManager _instance;
    public static UpdatePetManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UpdatePetManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("UpdatePetManager");
                    _instance = obj.AddComponent<UpdatePetManager>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        danhSachPet.Add("water");
        danhSachPet.Add("fire");
        danhSachPet.Add("lighting");
        danhSachPet.Add("acid");
        danhSachPet.Add("wind");

    }

    


    private List<string> GetListPetUpdate()
    {
        List<string> list = new List<string>();
        
        if (danhSachPetDaNangCap.Count <3)
        {
            List<string> petCoTheChon = new List<string>(danhSachPet); // Tạo danh sách tạm thời

            while (list.Count < 3 && petCoTheChon.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, petCoTheChon.Count);
                string pet = petCoTheChon[index];
                list.Add(pet);
                petCoTheChon.RemoveAt(index);
            }
        }
        else
        {
            return danhSachPetDaNangCap;
        }
        return list;
    }

    public void ShowUpdate()
    {

    }

    
}
