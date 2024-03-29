﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private Transform groundDetection;
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private float howFarFromWallToTurnAround = 0.5f;
    [SerializeField] private bool isOnFloatingPlatform = false;
    [SerializeField] private bool shouldRotate = false;
    [SerializeField] private bool isWalkingRightForRotating = true;
    [SerializeField] private float rotationDegrees = 0;
    [SerializeField] private float howMuchToMoveForRotation = 1f;
    private Rigidbody2D rigidBody;
    private float rayDistance = 2f;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }

    public Transform GroundDetection
    {
        get
        {
            return groundDetection;
        }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = movementDirection.normalized * movementSpeed;
        if (!isWalkingRightForRotating)
        {
            howMuchToMoveForRotation *= -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 checkRayVector = rigidBody.velocity;
        if (isOnFloatingPlatform)
        {
            checkRayVector = -transform.up;
        }
        RaycastHit2D hit = Physics2D.Raycast(groundDetection.position, checkRayVector, rayDistance, LayerMask.GetMask(GameConstants.GROUND_LAYER, GameConstants.HAZARDS_LAYER));
        if (hit.collider != null && !isOnFloatingPlatform)
        {
            Vector2 objectPosition = new Vector2(groundDetection.transform.position.x, groundDetection.transform.position.y);
            float distanceRayCollision = (hit.point - objectPosition).magnitude;
            if (distanceRayCollision < howFarFromWallToTurnAround)
            {
                ChangeDirection();
            }
        }
        else if (hit.collider == null && isOnFloatingPlatform)
        {
            if (!shouldRotate)
            {
                ChangeDirection();
            }
            else
            {
                RotateAround();
            }
        }
        if (IsEnemyMoving() && !shouldRotate)
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
        transform.Rotate(0f, 0f, rotationDegrees);
        rigidBody.transform.position += transform.right * howMuchToMoveForRotation;
        if (isWalkingRightForRotating)
        {
            rigidBody.velocity = transform.right * movementSpeed;
        }
        else
        {
            rigidBody.velocity = -transform.right * movementSpeed;
        }
    }

    public void ChasePlayer(Transform playerPosition, bool shouldChasePlayer)
    {
        if (shouldChasePlayer)
        {
            rigidBody.velocity = new Vector2(playerPosition.transform.position.x - transform.position.x, 0f).normalized * movementSpeed;
        }
    }

    public void FlipAround(Transform playerPosition)
    {
        if (playerPosition.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void StopMoving()
    {
        rigidBody.velocity = new Vector2(0f, 0f);
    }

}
