using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StabilityBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int maxValue;

    public void SetMaxStability(int stability)
    {
        slider.maxValue = stability;
        slider.value = stability;
        maxValue = stability;
    }

    public void ChangeStability(int stability)
    {
        if (slider.value + stability >= maxValue)
        {
            StartCoroutine(UpdateStabilityBar(maxValue - slider.value));
        }
        else
        {
            StartCoroutine(UpdateStabilityBar(stability));
        }

    }
    IEnumerator UpdateStabilityBar(float stabilityChange)
    {
        if (stabilityChange > 0)
        {
            while (stabilityChange > 0)
            {
                slider.value += 1;
                stabilityChange -= 1;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else if (stabilityChange < 0)
        {
            while (stabilityChange < 0)
            {
                slider.value -= 1;
                stabilityChange += 1;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            yield return null;
        }
    }
    

    public float getStability()
    {
        return slider.value;
    }

    public void setStartStability(float startStability)
    {
        slider.value = startStability; 
    }
}
