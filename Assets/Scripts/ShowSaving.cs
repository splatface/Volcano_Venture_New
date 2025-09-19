using UnityEngine;

public class ShowSaving : MonoBehaviour
{

    public GameObject savingIcon;
    public Canvas parentCanvas;
    // the slider from the heatbarcode

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            parentCanvas.enabled = true;
        }
        else
        {
            parentCanvas.enabled = false;
            
        }
    }
}
