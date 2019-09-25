using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private float detectPlayerRange = 10f;
    [SerializeField] private float attackRange = 2f;
    private float distanceBetweenEnemyAndPlayer;

    enum EnemyState
    {
        walking,
        attacking,
        chasing
    }

    EnemyState enemyState = EnemyState.walking;

    // Update is called once per frame
    void Update()
    {
        distanceBetweenEnemyAndPlayer = Vector2.Distance(FindObjectOfType<PlayerMovement>().transform.position, transform.position);
        bool shouldWalk = distanceBetweenEnemyAndPlayer > detectPlayerRange;
        bool shouldChase = distanceBetweenEnemyAndPlayer <= detectPlayerRange && distanceBetweenEnemyAndPlayer > attackRange;
        bool shouldAttack = distanceBetweenEnemyAndPlayer <= attackRange;
        if (shouldWalk)
        {
            StopAllCoroutines();
            enemyState = EnemyState.walking;
        }
        if (shouldChase)
        {
            StopAllCoroutines();
            StartCoroutine(ChasePlayer());
        }
        if (shouldAttack)
        {
            StopAllCoroutines();
            enemyState = EnemyState.attacking;
        }

        //
        switch (enemyState)
        {
            case EnemyState.walking:
                //TODO 
                //call walk function
                if(distanceBetweenEnemyAndPlayer <= detectPlayerRange)
                {
                    //exit walking 
                    //enter chase()-> enemystate.chasing
                    
                }
                break;
            case EnemyState.chasing:
                //TODO 
                //call chase function
                //if(further) exit chase+enter walk
                //else excit chase + enter attack
                break;
            case EnemyState.attacking:
                //TODO 
                break;
        }

        //transform.localScale = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x), 1f);
    }

    private IEnumerator ChasePlayer()
    {
        enemyState = EnemyState.chasing;
        while (distanceBetweenEnemyAndPlayer >= attackRange)
        {
            //movement.chaseplayer(bool shouldchase);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(FindObjectOfType<PlayerMovement>().transform.position.x, transform.position.y), GetComponent<EnemyMovementRaycast>().MovementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
