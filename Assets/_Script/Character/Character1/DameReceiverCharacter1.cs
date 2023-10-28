using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameReceiverCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    protected CharacterStats character;

    void Start()
    {
        character = GameObject.Find("Player1").GetComponent<Character1Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void Receive(int dame)
    {
        character.health -= (dame - character.armor);
    }
}
