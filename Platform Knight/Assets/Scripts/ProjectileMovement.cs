using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 7f;

    private Rigidbody2D rigidBody;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        transform.localScale = new Vector2(playerAttack.FacingDirectionAtTimeOfAttack, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            rigidBody.velocity = new Vector2(projectileSpeed, 0f);
        }
        else
        {
            rigidBody.velocity = new Vector2(-projectileSpeed, 0f);
        }
    }
}
