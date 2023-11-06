using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetStats : MonoBehaviour
{
    // Start is called before the first frame update

    public string name;
    public int star;
    public int atk;
    public float cooldown;
    public int atkBuff;
    public int critBuff;
    public int speedRunBuff;
    public int speedAttachBuff;
    public int hpBuff;
    public int dameCritBuff;
    public int armorBuff;

    public int level = 0;
    public int levelMax =3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void upLevel1()
    {

    }
    public virtual void upLevel2()
    {

    }
    public virtual void upLevel3()
    {

    }
}
