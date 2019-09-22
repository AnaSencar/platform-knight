using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrawlerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private bool isWalkingright = true;
    private Rigidbody2D rigidBody;

    public bool IsWalkingright
    {
        get
        {
            return isWalkingright;
        }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkingright)
        {
            rigidBody.velocity = transform.right * movementSpeed;
        }
        else
        {
            rigidBody.velocity = -transform.right * movementSpeed;
        }
    }
}
