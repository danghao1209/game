using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUiRender : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TextDameWater;
    public Text TextCoolDownWater;
    public Text TextSupportWater;
    public Text TextDameFire;
    public Text TextCoolDownFire;
    public Text TextSupportFire;
    public Text TextDameWind;
    public Text TextCoolDownWind;
    public Text TextSupportWind;
    public Text TextDameLighting;
    public Text TextCoolDownLighting;
    public Text TextSupportLighting;
    public Text TextDameAcid;
    public Text TextCoolDownAcid;
    public Text TextSupportAcid;
    public Text TextDameDark;
    public Text TextCoolDownDark;
    public Text TextSupportDark;
    PetManager petManager;
    private void Awake()
    {
        petManager = PetManager.Instance;
    }
    void Start()
    {
        TextDameWater.text = petManager.water.atk.ToString();
        TextCoolDownWater.text = petManager.water.cooldown.ToString();
        TextSupportWater.text = petManager.water.hpBuff.ToString() + " %HP";
        TextDameFire.text = petManager.fire.atk.ToString();
        TextCoolDownFire.text = petManager.fire.cooldown.ToString();
        TextSupportFire.text = petManager.fire.atkBuff.ToString() +" %ATK";
        TextDameWind.text = petManager.wind.atk.ToString();
        TextCoolDownWind.text = petManager.wind.cooldown.ToString();
        TextSupportWind.text = petManager.wind.speedAttachBuff.ToString() + " % Speed";
        TextDameLighting.text = petManager.lighting.atk.ToString();
        TextCoolDownLighting.text = petManager.lighting.cooldown.ToString();
        TextSupportLighting.text = petManager.lighting.critBuff.ToString() + " % Crit";
        TextDameAcid.text = petManager.acid.atk.ToString();
        TextCoolDownAcid.text = petManager.acid.cooldown.ToString();
        TextSupportAcid.text = petManager.acid.dameCritBuff.ToString() + " % DameCrit";
        TextDameDark.text = petManager.dark.atk.ToString();
        TextCoolDownDark.text = petManager.dark.cooldown.ToString();
        TextSupportDark.text = petManager.dark.atkBuff.ToString() + " % All";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
