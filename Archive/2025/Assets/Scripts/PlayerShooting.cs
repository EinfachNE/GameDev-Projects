using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private PlayerBehaviour player;

    [SerializeField] Transform weaponObject;
    [SerializeField] float maxShootingDistanz;

    private Vector2 shootingDir;
    private Vector2 weaponPos;

    private void Start()
    {
        player = References.player.GetComponent<PlayerBehaviour>();
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        shootingDir = (mousePos - new Vector2(transform.position.x + .5f, transform.position.y +.5f)).normalized;
        weaponPos = (new Vector2(transform.position.x, transform.position.y) + new Vector2(.5f, .5f)) + shootingDir;

        weaponObject.position = weaponPos;
    }


    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed) {
            RaycastHit2D hit = Physics2D.Raycast(weaponPos, shootingDir, maxShootingDistanz);
            if (hit.collider != null)
            {
                hit.collider.GetComponent<Enemy>()?.TakeDamage(player.GetFullDamageAmount());
            }
        }


    }



}
