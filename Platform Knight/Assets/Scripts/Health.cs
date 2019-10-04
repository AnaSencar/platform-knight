using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private BasicStats basicStats;
    private bool isDead = false;

    public bool IsDead
    {
        get
        {
            return isDead;
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
            GetComponent<Animator>().SetTrigger("Hurt");
        }
    }

    private IEnumerator Die()
    {
        RemoveColliders();
        GetComponent<Animator>().SetTrigger("Dead");
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

}
