using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpDistance = 5f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Health>().CanDoActions)
        {
            Move();
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            ChangeDirection();
        }
    }

    private void Move()
    {
        float sideToMove = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(sideToMove * moveSpeed, rigidBody.velocity.y);
        animator.SetBool(GameConstants.ISWALKING_ANIM_PAR, IsPlayerMoving());
    }

    private void Jump()
    {
        if (IsTouchingGround())
        {
            rigidBody.velocity += new Vector2(0f, jumpDistance);
        }
    }

    private void ChangeDirection()
    {
        if (IsPlayerMoving())
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }

    private bool IsPlayerMoving()
    {
        return Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
    }

    private bool IsTouchingGround()
    {
        return capsuleCollider.IsTouchingLayers(LayerMask.GetMask(GameConstants.GROUND_LAYER));
    }

    public void PushPlayer(Vector2 pushDirection, float pushForce)
    {
        rigidBody.AddForce(pushDirection * pushForce);
    }

}
