using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider health_slider;

    public void SetMaxHealth(short health)
    {
        health_slider.maxValue = health;
        health_slider.value = health;
    }

    public void SetMinHealth(short health)
    {
        health_slider.minValue = health;
        health_slider.value = health;
    }


    public void SetHealth(short health)
    {
        health_slider.value = health;
    }
} 
