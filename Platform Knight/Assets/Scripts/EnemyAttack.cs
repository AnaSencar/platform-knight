using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private float detectPlayerRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private bool shouldChasePlayer = false;
    [SerializeField] private float attackCooldown;
    [SerializeField] private bool isRanged = false;
    [SerializeField] private GameObject projectile;

    private float distanceBetweenEnemyAndPlayer;
    private float timeOfLastAttack = 0f;
    private Animator animator;
    private BoxCollider2D boxCollider;

    enum EnemyState
    {
        guarding,
        walking,
        chasing,
        attackingMelee,
        attackingRanged,
        dead
    }

    EnemyState enemyState = EnemyState.walking;

    public int AttackDamage
    {
        get
        {
            return attackDamage;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    void Update()
    {
        distanceBetweenEnemyAndPlayer = Vector2.Distance(FindObjectOfType<PlayerMovement>().transform.position, transform.position);
        bool isItTimeToAttackAgain = Time.time - timeOfLastAttack > attackCooldown;
        Health enemyHealth = GetComponent<Health>();
        if (enemyHealth.IsDead)
        {
            enemyState = EnemyState.dead;
        }
        switch (enemyState)
        {
            case EnemyState.guarding:
                if (distanceBetweenEnemyAndPlayer <= attackRange)
                {
                    SwitchState(EnemyState.attackingRanged);
                }
                break;
            case EnemyState.walking:
                if(distanceBetweenEnemyAndPlayer <= detectPlayerRange)
                {
                    SwitchState(EnemyState.chasing);
                }
                break;
            case EnemyState.chasing:
                ChasePlayer();
                if(distanceBetweenEnemyAndPlayer > detectPlayerRange)
                {
                    SwitchState(EnemyState.walking);
                }
                else if (distanceBetweenEnemyAndPlayer <= attackRange)
                {
                    SwitchState(EnemyState.attackingMelee);
                }
                break;
            case EnemyState.attackingMelee:
                ChasePlayer();
                if (isItTimeToAttackAgain)
                {
                    SwitchState(EnemyState.chasing);
                }
                break;
            case EnemyState.attackingRanged:
                if (isItTimeToAttackAgain)
                {
                    SwitchState(EnemyState.guarding);
                }
                break;
            case EnemyState.dead:
                GetComponent<EnemyMovement>().StopMoving();
                break;
        }
    }

    private void ChasePlayer()
    {
        if (distanceBetweenEnemyAndPlayer <= attackRange)
        {
            GetComponent<EnemyMovement>().StopMoving();
        }
        else
        {
            GetComponent<EnemyMovement>().ChasePlayer(FindObjectOfType<PlayerMovement>().transform, shouldChasePlayer);
        }
    }

    private void AttackMelee()
    {
        animator.SetTrigger("Attack");
    }

    private void AttackRanged()
    {

    }

    private void SwitchState(EnemyState newState)
    {
        enemyState = newState;
        EnterState();
    }

    private void EnterState()
    {
        switch (enemyState)
        {
            case EnemyState.walking:
                break;
            case EnemyState.chasing:
                break;
            case EnemyState.attackingMelee:
                AttackMelee();
                timeOfLastAttack = Time.time;
                break;
        }
    }

    private void AddColliderOnEnemyAnimationEvent()
    {
        boxCollider.enabled = true;
    }

    private void RemoveColliderOnEnemyAnimationEvent()
    {
        boxCollider.enabled = false;
    }

}
