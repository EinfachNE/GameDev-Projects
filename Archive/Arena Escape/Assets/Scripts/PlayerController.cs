using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float drag = .9f;

    private PlayerControls playerControls;
    private Vector2 movement;

    private bool isGrounded;
    [SerializeField] BoxCollider2D groundCheck;
    [SerializeField] LayerMask groundMask;

    private Rigidbody2D rb;


    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Movement.Jump.performed += Jump;
    }
    private void OnDisable()
    {
        playerControls.Movement.Jump.performed -= Jump;
        playerControls.Disable();
    }
    private void Update()
    {
        PlayerInput();
        CheckGround();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Mathf.Abs(movement.x) > 0)
        {
            rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (isGrounded)
        {
            rb.linearVelocityX *= drag;
        }
    }
    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
}
