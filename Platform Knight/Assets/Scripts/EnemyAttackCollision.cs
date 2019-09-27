using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (!GetComponentInParent<Health>().IsDead)
            {
                playerHealth.TakeDamage(GetComponentInParent<EnemyAttack>().AttackDamage);
            }
        }
    }
}
