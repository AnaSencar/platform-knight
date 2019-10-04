using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 7f;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.right * projectileSpeed;
    }
}
