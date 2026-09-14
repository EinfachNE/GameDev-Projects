using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y, 0).normalized;
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, movement.y * moveSpeed, movement.z * moveSpeed);
    }
}
