using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    public Text valueText;
    int progressValue = 0;

    public Slider slider;
    public void OnSliderChanged(float value)
    {
            valueText.text = value.ToString()+"%";
    }

    public void UpdateProgress(int progress)
    {
        if(slider.value < 100) {
            progressValue += progress;
        }
        slider.value = progressValue;
    }
}
