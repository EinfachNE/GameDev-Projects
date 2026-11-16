using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool hasClickedDestination = false;
    private Vector2 lastClickedDestination;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
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
        input = inputActions.Gameplay.Move.ReadValue<Vector2>();
    }
    private void Move()
    {
        Vector2 movement = new Vector2(input.x, input.y).normalized;
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, movement.y * moveSpeed, 0);
        if (input != Vector2.zero)
        {
            hasClickedDestination = false;
        }
        else if(input == Vector2.zero && hasClickedDestination)
        {
            movement = new Vector2(lastClickedDestination.x - transform.position.x, lastClickedDestination.y - transform.position.y).normalized;
            rb.linearVelocity = new Vector3(movement.x * moveSpeed, movement.y * moveSpeed, 0);
            if (Vector2.Distance(transform.position, lastClickedDestination) <= 1f)
            {
                hasClickedDestination = false;
            }
        }
    }
    public void ClickMoveTowards(Vector2 destination)
    {
        lastClickedDestination = destination;
        hasClickedDestination = true;
    }
}
