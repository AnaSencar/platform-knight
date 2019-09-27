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

    private float distanceBetweenEnemyAndPlayer;
    private float timeOfLastAttack = 0f;
    private Animator animator;
    private BoxCollider2D boxCollider;

    enum EnemyState
    {
        walking,
        attacking,
        chasing
    }

    EnemyState enemyState = EnemyState.walking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenEnemyAndPlayer = Vector2.Distance(FindObjectOfType<PlayerMovement>().transform.position, transform.position);
        //bool shouldWalk = distanceBetweenEnemyAndPlayer > detectPlayerRange;
        //bool shouldChase = distanceBetweenEnemyAndPlayer <= detectPlayerRange && distanceBetweenEnemyAndPlayer > attackRange;
        //bool shouldAttack = distanceBetweenEnemyAndPlayer <= attackRange;
        //if (shouldWalk)
        //{
        //    enemyState = EnemyState.walking;
        //}
        //if (shouldChase)
        //{
        //    StateChasePlayer();
        //}
        //if (shouldAttack && (Time.time - timeOfLastAttack > attackCooldown))
        //{
        //    AttackTarget();
        //    timeOfLastAttack = Time.deltaTime;
        //}

        bool isItTimeToAttackAgain = Time.time - timeOfLastAttack > attackCooldown;
        Debug.Log(Time.time - timeOfLastAttack);
        Debug.Log(isItTimeToAttackAgain);

        //
        switch (enemyState)
        {
            case EnemyState.walking:
                Debug.Log("Walking");
                if(distanceBetweenEnemyAndPlayer <= detectPlayerRange)
                {
                    enemyState = EnemyState.chasing;
                    Debug.Log("Switching to chase");
                }
                break;
            case EnemyState.chasing:
                StateChasePlayer();
                if(distanceBetweenEnemyAndPlayer > detectPlayerRange)
                {
                    Debug.Log("switch to walk");
                    enemyState = EnemyState.walking;
                }
                else if (distanceBetweenEnemyAndPlayer <= attackRange)
                {
                    Debug.Log("switch to attack");
                    enemyState = EnemyState.attacking;
                    AttackTarget();
                    timeOfLastAttack = Time.time;
                    

                }


                //TODO 
                //call chase function
                //if(further) exit chase+enter walk
                //else excit chase + enter attack
                break;
            case EnemyState.attacking:
                //TODO 
                StateChasePlayer();
                Debug.Log("in attack");
                
                if (isItTimeToAttackAgain)
                {
                    enemyState = EnemyState.chasing;
                    Debug.Log("back to chase");
                }
                break;
        }



    }

    private void StateChasePlayer()
    {
        //enemyState = EnemyState.chasing;
        if (distanceBetweenEnemyAndPlayer <= attackRange)
        {
            GetComponent<EnemyMovement>().StopMoving();
        }
        else
        {
            GetComponent<EnemyMovement>().ChasePlayer(FindObjectOfType<PlayerMovement>().transform, shouldChasePlayer);
        }
    }

    private void AttackTarget()
    {
        animator.SetTrigger("Attack");
        Debug.Log("do animation");
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
            case EnemyState.chasing:
                break;
            case EnemyState.attacking:
                AttackTarget();
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
