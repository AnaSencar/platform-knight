using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetection : MonoBehaviour
{
    [SerializeField] private AttackTypes attackType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameConstants.PLAYER_TAG)
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (gameObject.tag != GameConstants.ENEMY_PROJECTILE_TAG)
            {
                if (!GetComponentInParent<Health>().IsDead)
                {
                    playerHealth.TakeDamage(GetComponentInParent<EnemyAttack>().AttackDamage);
                }
            }
            else
            {
                playerHealth.TakeDamage(attackType.AttackDamage);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == GameConstants.ENEMY_TAG && gameObject.tag != GameConstants.ENEMY_TAG && gameObject.tag != GameConstants.ENEMY_PROJECTILE_TAG) 
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.TakeDamage(attackType.AttackDamage);
            if (enemyHealth.IsDead) 
            {
                if (gameObject.tag != GameConstants.PLAYER_PROJECTILE_TAG)
                {
                    gameObject.GetComponentInParent<BasicStats>().RegainMana(collision.gameObject.GetComponent<BasicStats>().ManaToGiveAfterKilled);
                }
                else
                {
                    FindObjectOfType<PlayerMovement>().GetComponent<BasicStats>().RegainMana(collision.gameObject.GetComponent<BasicStats>().ManaToGiveAfterKilled);
                }
            }
            if (gameObject.tag == GameConstants.PLAYER_PROJECTILE_TAG)
            {
                Destroy(gameObject);
            }
        }

        if ((gameObject.tag == GameConstants.ENEMY_PROJECTILE_TAG || gameObject.tag == GameConstants.PLAYER_PROJECTILE_TAG) && collision.gameObject.layer == LayerMask.NameToLayer(GameConstants.GROUND_LAYER)) 
        {
            Destroy(gameObject);
        }
    }

    public void SetAttackType(AttackTypes newAttackType)
    {
        attackType = newAttackType;
    }

}
