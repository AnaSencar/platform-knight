using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRaycast : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private Transform groundDetection;
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private float howFarFromWallToTurnAround = 0.5f;
    [SerializeField] private bool isOnFloatingPlatform = false;
    [SerializeField] private bool shouldRotate = false;
    [SerializeField] private float rotationDegrees = 0;
    private Rigidbody2D rigidBody;
    private float rayDistance = 2f;

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
        rigidBody.velocity = movementDirection.normalized * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 checkRayVector = rigidBody.velocity;
        if (isOnFloatingPlatform)
        {
            checkRayVector = Vector2.down;
        }
        //if should chase, call chaseplayer else code below
        RaycastHit2D hit = Physics2D.Raycast(groundDetection.position, checkRayVector, rayDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null && !isOnFloatingPlatform)
        {
            Vector2 objectPosition = new Vector2(groundDetection.transform.position.x, groundDetection.transform.position.y);
            float distanceRayCollision = (hit.point - objectPosition).magnitude;
            Debug.Log(distanceRayCollision);
            if (distanceRayCollision < howFarFromWallToTurnAround)
            {
                ChangeDirection();
            }
        }
        else if (hit.collider == null && isOnFloatingPlatform)
        {
            ChangeDirection();
        }
        if (IsEnemyMoving())
        {
            ChangeSpritePosition();
        }
    }

    private bool IsEnemyMoving()
    {
        return rigidBody.velocity.sqrMagnitude > Mathf.Epsilon;
    }

    private void ChangeDirection()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x * -1, rigidBody.velocity.y * -1);
    }

    private void ChangeSpritePosition()
    {
        transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
    }

    private void RotateAround()
    {
        transform.Rotate(0f, 0f, 90f);
    }

    //private void chaseplayer(){...}

}
