using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private BasicStats basicStats;
    private bool isDead = false;
    private bool canAttack = true;

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    public bool CanAttack
    {
        get
        {
            return canAttack;
        }
    }

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
            StartCoroutine(Die());
        }
        else if (basicStats.CurrentHealth > 0) 
        {
            StartCoroutine(GettingHurt());
        }
    }

    private IEnumerator GettingHurt()
    {
        canAttack = false;
        GetComponent<Animator>().SetTrigger(GameConstants.HURT_ANIMATION);
        RemoveAttackCollider();
        float animationLength = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);
        canAttack = true;
    }

    private IEnumerator Die()
    {
        RemoveColliders();
        GetComponent<Animator>().SetTrigger(GameConstants.DEAD_ANIMATION);
        yield return new WaitForEndOfFrame();
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    private void RemoveColliders()
    {
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach(Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }

    private void RemoveAttackCollider()
    {
        GetComponentInChildren<BoxCollider2D>().enabled = false;
    }

    public void RegainHealth(int regainAmount)
    {
        basicStats.CurrentHealth = Mathf.Clamp(basicStats.CurrentHealth + regainAmount, 0, basicStats.MaxHealth);
    }

}
