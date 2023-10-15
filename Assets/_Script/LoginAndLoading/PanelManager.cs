using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject registerFailText;
    [SerializeField]
    public void TransToRegister()
    {
        
        this.registerFailText.SetActive(true);
    }
}
