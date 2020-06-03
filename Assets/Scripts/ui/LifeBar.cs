using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [HideInInspector]
    public Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>(); 
    }

    public void Setup(float maxLife, Vector2 position)
    {
        slider.minValue = 0f;
        slider.maxValue = maxLife;
        slider.value = maxLife;
    }

    public void UpdateLife(float life)
    {
        slider.value = life;
    }

    public void MoveToUntranslatedCoords(Vector2 coords)
    {
        
        transform.position = Camera.main.WorldToScreenPoint(coords);;
    }
}