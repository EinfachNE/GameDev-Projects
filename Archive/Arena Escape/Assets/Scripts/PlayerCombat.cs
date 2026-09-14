using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = .5f;
    [SerializeField] private LayerMask enemyLayer;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Combat.Attack.performed += Attack;
    }
    private void OnDisable()
    {
        playerControls.Combat.Attack.performed -= Attack;
        playerControls.Disable();
    }

    private void Attack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        Debug.Log(hitEnemies.Length);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)  return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
