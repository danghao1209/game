using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLifeTimeSkillCharacter2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

}
