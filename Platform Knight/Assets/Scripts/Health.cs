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
        else
        {
            GetComponent<Animator>().SetTrigger("Hurt");
        }
    }

    private IEnumerator Die()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForEndOfFrame();
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

}
