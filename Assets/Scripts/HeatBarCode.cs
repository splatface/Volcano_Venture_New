using UnityEngine;
using UnityEngine.UI;

public class HeatBarCode : MonoBehaviour
{
    // declares heatBar slider here
    public Slider heatBar;

    // sets min and max values when it is initialized
    void Start()
    {
        heatBar = GetComponent<Slider>();
        heatBar.maxValue = 180;
        heatBar.minValue = 0;

        heatBar.value = heatBar.maxValue;
    }

    // updates the heatbar so it decreases every frame
    void Update()
    {
        heatBar.value -= 0.05f;
    }

}