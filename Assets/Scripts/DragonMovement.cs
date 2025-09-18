using UnityEngine;

public class dragon : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 10f;

    [SerializeField]
    public float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D dragonBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;
    }
}
