using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFloorClearManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Slider slider;
    [SerializeField] FloorTracker floors;
    [SerializeField] Text count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public float GetMinValue()
    {
        return slider.minValue;
    }


    public float GetMaxValue()
    {
        return slider.maxValue;
    }

    public void Upgrade()
    {
        if (slider.minValue == 0)
        {
            slider.minValue = 18;
            slider.maxValue = 20;
            slider.value = 20;
        }
        else
        {
            slider.minValue -= 1;
            slider.maxValue += 2;

            if(slider.value == slider.minValue + 1)
            {
                slider.value = slider.minValue;
            }
            else if (slider.value == slider.maxValue - 2)
            {
                slider.value = slider.maxValue;
            }
        }
    }

    public void OnSliderChange(int value)
    {
        count.text = value.ToString();
        floors.SetQueueSize(value);
    }
}
