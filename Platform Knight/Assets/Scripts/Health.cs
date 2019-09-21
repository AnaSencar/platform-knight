using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private BasicStats basicStats;
    private bool isDead = false;

    private void Awake()
    {
        basicStats = GetComponent<BasicStats>();
    }

    public void TakeDamage(int damageToTake)
    {
        basicStats.CurrentHealth = Mathf.Max(basicStats.CurrentHealth - damageToTake, 0);
        if (basicStats.CurrentHealth <= 0)
        {
            isDead = true;
            Die();
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Hurt");
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

}
