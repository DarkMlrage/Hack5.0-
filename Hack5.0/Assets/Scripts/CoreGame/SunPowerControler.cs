using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SunPowerControler : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float minValue;
    [SerializeField] float maxValue;

    public float sunPowerValue;

    private void Awake()
    {
        slider = GetComponent<Slider>();

        slider.maxValue = maxValue;
        slider.minValue = minValue;
    }

    public void UpdateUI()
    {
        slider.value = sunPowerValue;
    }

    public void AddSunPower(float value)
    {
        sunPowerValue += value;
        UpdateUI();
    }

}
