using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementVertical : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private bool isMovingUp = true;
    private Rigidbody2D rigidBody;

    public bool IsMovingUp
    {
        get
        {
            return isMovingUp;
        }
        set
        {
            isMovingUp = value;
        }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingUp)
        {
            rigidBody.velocity = new Vector2(0f, movementSpeed);
        }
        else
        {
            rigidBody.velocity = new Vector2(0f, -movementSpeed);
        }
    }
}
