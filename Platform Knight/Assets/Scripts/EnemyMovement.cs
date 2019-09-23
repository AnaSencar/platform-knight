using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody2D rigidBody;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            rigidBody.velocity = new Vector2(movementSpeed, 0f);
        }
        else
        {
            rigidBody.velocity = new Vector2(-movementSpeed, 0f);
        }
    }



}
