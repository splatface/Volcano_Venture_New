using UnityEngine;
using UnityEngine.InputSystem;

public class ShowSaving : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            
        }
    }
}
