using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
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
        if (collision.gameObject.tag == "Enemy")
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(10);
        }
    }
}
