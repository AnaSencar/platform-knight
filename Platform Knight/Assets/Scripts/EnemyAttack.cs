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
    }

    private IEnumerator ChasePlayer()
    {
        enemyState = EnemyState.chasing;
        while (distanceBetweenEnemyAndPlayer > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(FindObjectOfType<PlayerMovement>().transform.position.x, transform.position.y), GetComponent<EnemyMovement>().MovementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
