using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider shield_slider;

    public void SetMaxShield(short shield)
    {
        shield_slider.maxValue = shield;
        shield_slider.value = shield;
    }

    public void SetMinShield(short shield)
    {  
        shield_slider.minValue = shield; 
        shield_slider.value = shield;
    }

    public void SetShield(short shield)
    {
        shield_slider.value = shield;
    }
} 
