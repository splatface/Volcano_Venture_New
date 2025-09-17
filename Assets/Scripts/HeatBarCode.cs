using UnityEngine;
using UnityEngine.UI;

public class HeatBarCode : MonoBehaviour
{
    public Slider heatBar;
    void Start()
    {
        heatBar = GetComponent<Slider>();
        heatBar.maxValue = 180;
        heatBar.minValue = 0;

        heatBar.value = heatBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        heatBar.value -= 0.1f;
    }

}