using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private new Camera camera;
    private float inputAxis;
    private Vector2 velocity;
    private new Transform transform;

    public float moveSpeed = 8f;
    public float acceleration = 1.5f;
    public float maxJumpHeight = 4f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool isGrounded { get; private set; }
    public bool isJumping { get; private set; }
    public bool isSliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);
    public bool isRunning => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
        camera = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();
        isGrounded = rigidbody.CheckGrounds(boxCollider);
        if (isGrounded)
        {
            GroundedMovement();
        }
        if (isSliding)
        {
            
        }
        ApplyGravity();
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);

        isJumping = velocity.y > 0f;

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            isJumping = true;
            SoundManager.PlaySound(SoundType.JUMP, 0, false);
        }
    }
    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime * acceleration);
        if (rigidbody.RaycastLateral(Vector2.right * velocity.x))
        {
            velocity.x = 0;
        }

        if (velocity.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }
    }

    private void ApplyGravity()
    {
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;
        
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp")) {
            if (transform.DotTest(collision.GetContact(0).point, Vector2.up))
            {
                // Debug.Log(collision.GetContact(0).point);
                velocity.y = 0f;
            }
        }
    }
}
