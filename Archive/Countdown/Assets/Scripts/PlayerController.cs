using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;

    [SerializeField] private float moveSpeed;

    PlayerControls playerControls;
    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void PlayerInput()
    {
        input = playerControls.Movement.Move.ReadValue<Vector2>();
    }
    private void Move()
    {
        Vector3 movement = new Vector3(input.x, input.y, 0).normalized;
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, movement.y * moveSpeed, movement.z * moveSpeed);
    }
}
