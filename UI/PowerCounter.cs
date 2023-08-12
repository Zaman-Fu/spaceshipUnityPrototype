using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI powerDisplayText;
    [SerializeField]
    Slider powerCounterSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPower(int power)
    {
        powerDisplayText.text = power.ToString();
        powerCounterSlider.value = power;
    }
}
