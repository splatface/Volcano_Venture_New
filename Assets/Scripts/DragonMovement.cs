using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

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

    private string OBSTACLE_TAG = "Obstacles";

    private Vector2 startPosition = new Vector2(7.77f, -1.73f);
    private float heat = 0f;
    public float heatIncreaseRate = 1f;

    public float speed = 5f;

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


        // TALK ABOUT HEAT BAR WITH TIFFANY TMR
        heat += heatIncreaseRate * Time.deltaTime;
        if (heat >= 20f)
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
        heat = 0f;
    }

}
