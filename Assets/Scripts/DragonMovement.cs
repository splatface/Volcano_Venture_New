using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dragon : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 2f;

    [SerializeField]
    public float jumpForce = 11f;

    private float movementX;
    private Rigidbody2D dragonBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string OBSTACLE_TAG = "Obstacle";

    private Vector2 startPosition = new Vector2(7.37f, 0.04f);
    public float heatIncreaseRate = 1f;

    public float speed = 3f;

    public Slider heatBar;

    void Start()
    {
        dragonBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
        dragonBody.gravityScale = 4.5f;
    }

    void Update()
    {
        DragonMoveKeyboard();
        AnimateDragon();
        DragonJump();


        if (heatBar.value <= 0)
        {
            ResetDragon();
        }
    }

    void DragonMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimateDragon()
    {
        if (movementX > 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void DragonJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            isGrounded = false;
            dragonBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        // HAVE TO MAKE OBSTACLE TAGS ON SELENAS CODE THAT'S ALL!!!
        if (collision.gameObject.CompareTag(OBSTACLE_TAG))
        {
            ResetDragon();
        }
    }

    private void ResetDragon()
    {
        transform.position = startPosition;
    }

}
