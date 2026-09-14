using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float acceleration = 80f;
    [SerializeField] private float deceleration = 100f;

    [Header("Jump / Gravity")]
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float gravity = -40f;
    [SerializeField] private float maxFallSpeed = -25f;
    [SerializeField] private float coyoteTime = 0.12f;
    [SerializeField] private float jumpHoldGravityMultiplier = 0.5f;
    [SerializeField] private float fallGravityMultiplier = 1.6f;
    [SerializeField] private float jumpCutMultiplier = 2.5f;
    [SerializeField] private float jumpBufferTime = 0.1f;


    [Header("Collision")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 boxSize = new Vector2(0.9f, 1.8f);
    [SerializeField] private float skinWidth = 0.02f;
    [SerializeField] private int horizontalRayCount = 4;
    [SerializeField] private int verticalRayCount = 4;

    [Header("Wall")]
    [SerializeField] private float wallCheckDistance = 0.08f;
    [SerializeField] private float wallSlideSpeed = -3f;
    [SerializeField] private Vector2 wallJumpForce = new Vector2(10f, 14f);
    [SerializeField] private float wallJumpControlLock = 0.15f;
    

    [Header("Corner Correction")]
    [SerializeField] private float cornerCorrectionDistance = 0.12f;
    [SerializeField] private int cornerCorrectionSteps = 4;

    private bool isTouchingWall;
    private int wallDirection;
    private float wallJumpControlLockTimer;

    private Vector2 velocity;
    private Vector2 input;
    private bool isGrounded;

    private float coyoteTimer;
    private float jumpBufferTimer;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
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
    }

    private void FixedUpdate()
    {
        wallJumpControlLockTimer -= Time.fixedDeltaTime;

        UpdateCoyoteTime();
        UpdateJumpBufferTime();

        CheckWall();
        ApplyMovement();
        if (isTouchingWall && !isGrounded && velocity.y < 0f)
        {
            velocity.y = Mathf.Max(velocity.y, wallSlideSpeed);
        }
        ApplyGravity();

        MoveHorizontal();
        MoveVertical();

    }


    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isGrounded || coyoteTimer > 0f)
        {
            velocity.y = jumpForce;
            isGrounded = false;
            coyoteTimer = 0f;
        }
        else if (isTouchingWall)
        {
            velocity.x = -wallDirection * wallJumpForce.x;
            velocity.y = wallJumpForce.y;

            wallJumpControlLockTimer = wallJumpControlLock;
        }
    }

    private void PlayerInput()
    {
        input = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void UpdateCoyoteTime()
    {
        if (isGrounded)
            coyoteTimer = coyoteTime;
        else
            coyoteTimer -= Time.fixedDeltaTime;
    }

    private void UpdateJumpBufferTime()
    {
        jumpBufferTimer -= Time.fixedDeltaTime;
    }

    private void ApplyMovement()
    {
        if (wallJumpControlLockTimer > 0f)
            return;

        float targetSpeed = input.x * moveSpeed;
        float rate = Mathf.Abs(input.x) > 0 ? acceleration : deceleration;

        velocity.x = Mathf.MoveTowards(
            velocity.x,
            targetSpeed,
            rate * Time.fixedDeltaTime
        );
    }

    private void CheckWall()
    {
        isTouchingWall = false;
        wallDirection = 0;

        if (isGrounded)
            return;

        if (CastWall(Vector2.right))
        {
            isTouchingWall = true;
            wallDirection = 1;
        }
        else if (CastWall(Vector2.left))
        {
            isTouchingWall = true;
            wallDirection = -1;
        }
    }

    private bool CastWall(Vector2 direction)
    {
        Vector2 center = transform.position;
        Vector2 halfSize = boxSize * 0.5f;

        float rayOriginX = center.x + halfSize.x * direction.x;
        float bottom = center.y - halfSize.y + skinWidth;
        float top = center.y + halfSize.y - skinWidth;

        float raySpacing = (top - bottom) / (horizontalRayCount - 1);

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 origin = new Vector2(
                rayOriginX,
                bottom + raySpacing * i
            );

            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                direction,
                wallCheckDistance,
                groundLayer
            );

            if (hit.collider != null)
                return true;
        }

        return false;
    }

    private bool TryCornerCorrection(int hitRayIndex)
    {
        int preferredDirection;

        if (hitRayIndex < verticalRayCount / 2)
            preferredDirection = 1;   
        else
            preferredDirection = -1;  

        if (TryCornerCorrectionDirection(preferredDirection))
            return true;

        return TryCornerCorrectionDirection(-preferredDirection);
    }

    private bool TryCornerCorrectionDirection(int direction)
    {
        for (int i = 1; i <= cornerCorrectionSteps; i++)
        {
            float offset = cornerCorrectionDistance / cornerCorrectionSteps * i;
            Vector2 correction = Vector2.right * direction * offset;

            if (CanMoveTo(correction))
            {
                transform.position += (Vector3)correction;
                return true;
            }
        }

        return false;
    }

    private bool CanMoveTo(Vector2 offset)
    {
        return !Physics2D.OverlapBox(
            (Vector2)transform.position + offset,
            boxSize - Vector2.one * skinWidth * 2f,
            0f,
            groundLayer
        );
    }

    private void ApplyGravity()
    {
        float gravityMultiplier = 1f;
        bool jumpHeld = playerControls.Movement.Jump.IsPressed();

        if (velocity.y > 0f && jumpHeld)
        {
            gravityMultiplier = jumpHoldGravityMultiplier;
        }
        else if (velocity.y > 0f && !jumpHeld)
        {
            gravityMultiplier = jumpCutMultiplier;
        }
        else if (velocity.y < 0f)
        {
            gravityMultiplier = fallGravityMultiplier;
        }

        velocity.y += gravity * gravityMultiplier * Time.fixedDeltaTime;
        velocity.y = Mathf.Max(velocity.y, maxFallSpeed);
    }

    private void MoveHorizontal()
    {
        float moveAmount = velocity.x * Time.fixedDeltaTime;

        if (Mathf.Approximately(moveAmount, 0f))
            return;

        float direction = Mathf.Sign(moveAmount);
        float distance = Mathf.Abs(moveAmount) + skinWidth;

        Vector2 center = transform.position;
        Vector2 halfSize = boxSize * 0.5f;

        float rayOriginX = center.x + halfSize.x * direction;
        float bottom = center.y - halfSize.y + skinWidth;
        float top = center.y + halfSize.y - skinWidth;

        float raySpacing = (top - bottom) / (horizontalRayCount - 1);

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 origin = new Vector2(
                rayOriginX,
                bottom + raySpacing * i
            );

            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                Vector2.right * direction,
                distance,
                groundLayer
            );

            Debug.DrawRay(origin, Vector2.right * direction * distance, Color.red);

            if (hit.collider != null)
            {
                moveAmount = (hit.distance - skinWidth) * direction;
                velocity.x = 0f;
                break;
            }
        }

        transform.position += new Vector3(moveAmount, 0f, 0f);
    }

    private void MoveVertical()
    {
        float moveAmount = velocity.y * Time.fixedDeltaTime;

        if (Mathf.Approximately(moveAmount, 0f))
            return;

        float direction = Mathf.Sign(moveAmount);
        float distance = Mathf.Abs(moveAmount) + skinWidth;

        Vector2 center = transform.position;
        Vector2 halfSize = boxSize * 0.5f;

        float rayOriginY = center.y + halfSize.y * direction;
        float left = center.x - halfSize.x + skinWidth;
        float right = center.x + halfSize.x - skinWidth;

        float raySpacing = (right - left) / (verticalRayCount - 1);

        isGrounded = false;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 origin = new Vector2(
                left + raySpacing * i,
                rayOriginY
            );

            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                Vector2.up * direction,
                distance,
                groundLayer
            );

            Debug.DrawRay(origin, Vector2.up * direction * distance, Color.blue);

            if (hit.collider != null)
            {
                if (direction > 0f && TryCornerCorrection(i))
                    return;

                moveAmount = (hit.distance - skinWidth) * direction;

                if (direction < 0f)
                    isGrounded = true;

                velocity.y = 0f;
                break;
            }
        }

        transform.position += new Vector3(0f, moveAmount, 0f);
    }

    public void AddVelocity(Vector2 amount)
    {
        velocity += amount;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
