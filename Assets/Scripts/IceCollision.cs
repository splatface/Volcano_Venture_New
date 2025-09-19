using UnityEngine;
using UnityEngine.UI;

public class IceCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider heatBar;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            heatBar.value += 40f;
            Destroy(gameObject);
        }
    }
}
