using UnityEngine;

public class IceCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "dragon_idle_0")
        {
            gameObject.SetActive(false);
        }
    }
}
