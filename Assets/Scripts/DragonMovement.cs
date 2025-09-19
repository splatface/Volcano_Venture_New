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

    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dragonBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DragonMoveKeyboard();
        AnimateDragon();
        DragonJump();
    }

    private void FixedUpdate()
    {
        DragonJump();
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
        if (Input.GetButtonDown("Jump"))
        {
            dragonBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

}
