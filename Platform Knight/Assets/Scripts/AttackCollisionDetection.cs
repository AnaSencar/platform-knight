using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetection : MonoBehaviour
{
    [SerializeField] private AttackTypes attackType;

    public AttackTypes AttackType
    {
        set
        {
            attackType = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (gameObject.tag != "Projectile")
            {
                //TODO remove colliders of thing thats dying
                if (!GetComponentInParent<Health>().IsDead)
                {
                    playerHealth.TakeDamage(GetComponentInParent<EnemyAttack>().AttackDamage);
                }
            }
            else
            {
                playerHealth.TakeDamage(5);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            //enemyHealth.TakeDamage(GetComponentInParent<PlayerAttack>().AttackDamage);
            if (gameObject.tag != "Projectile")
            {
                enemyHealth.TakeDamage(10);
            }
            else
            {
                Debug.Log("Enemy hit by projectile");
                enemyHealth.TakeDamage(5);
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "Projectile" && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Projectile") 
        {
            Destroy(gameObject);
        }
    }
}
