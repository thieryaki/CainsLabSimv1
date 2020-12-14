using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    [SerializeField]
    private TextMeshProUGUI display2;

    private Slider slider;

    private int upperAmount = 5;
    public float targetProgress = 45;
    public float TargetProgress {get => targetProgress; set => targetProgress = value; }

    public float FillSpeed = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (slider.value == 5)
        {
            upperAmount += 5;
            slider.value = 0f;
            targetProgress -= 5f;
            display.text = upperAmount + "mL";
            display2.text = (upperAmount - 5f) + "mL";
        }
        else if(slider.value < targetProgress)
        {
            slider.value += FillSpeed;
        }
        
        
    }

    public void IncrementWater(float newProgress)
    {
        slider.value += newProgress;
    }
}
