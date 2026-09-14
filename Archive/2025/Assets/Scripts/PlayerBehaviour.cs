using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Component References")]
    private Rigidbody2D rb;
    private PlayerStats playerStats;

    [Header("Player Settings")]
    [SerializeField] float moveSpeed;

    private Vector2 moveInput;

    private void Awake()
    {
        References.player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public int GetFullDamageAmount()
    {
        int value = playerStats.GetDamageAmount();
        return value;
    }
    
}
