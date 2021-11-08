using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxBattery(int MaxBattery)
    {
        slider.maxValue = MaxBattery;

    }

    public void SetBattery(int battery)
    {
        slider.value = battery;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
