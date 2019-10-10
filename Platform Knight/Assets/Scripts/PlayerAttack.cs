using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private AttackTypes[] allAttackTypes;

    private Animator animator;
    private BoxCollider2D boxCollider;
    private float timeOfLastAttack = 0f;
    private BasicStats basicStats;
    private AttackCollisionDetection attackDetection;
    private Dictionary<string, AttackTypes> attackTypesDictionary = new Dictionary<string, AttackTypes>();
    private bool isPlayerUsingRangedAttack = false;
    private bool isHealing = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        attackDetection = GetComponentInChildren<AttackCollisionDetection>();
        basicStats = GetComponent<BasicStats>();
        SetUpAttackTypesDictionary();
        boxCollider.enabled = false;
    }

    void Update()
    {
        bool canAttackAgain = Time.time - timeOfLastAttack > attackCooldown;
        if (GetComponent<Health>().CanDoActions && canAttackAgain)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Attack(GameConstants.BASIC_ATTACK_ANIMATION));
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(Attack(GameConstants.STRIKE_ATTACK_ANIMATION));
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                isPlayerUsingRangedAttack = true;
                StartCoroutine(Attack(GameConstants.CAST_ATTACK_ANIMATION));
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                isHealing = true;
                StartCoroutine(Attack(GameConstants.HEAL_ANIMATION));
            }
        }
    }

    private IEnumerator Attack(string attackName)
    {
        if (attackTypesDictionary[attackName].ManaCostUsage <= basicStats.CurrentMana)
        {
            basicStats.CurrentMana -= attackTypesDictionary[attackName].ManaCostUsage;
            timeOfLastAttack = Time.time;
            animator.SetTrigger(attackName);
            if (!isPlayerUsingRangedAttack & !isHealing) 
            {
                attackDetection.SetAttackType(attackTypesDictionary[attackName]);
            }
            if (isHealing)
            {
                GetComponent<Health>().RegainHealth(attackTypesDictionary[attackName].HealAmount);
            }
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            if (isPlayerUsingRangedAttack & !isHealing)
            {
                Vector3 newSpawnPosition = projectileSpawnLocation.position;
                Quaternion newRotationForPosition = projectileSpawnLocation.rotation;
                if (transform.localScale.x < 0)
                {
                    newRotationForPosition.eulerAngles = new Vector3(0f, 0f, 180f);
                }
                var projectileInstance = Instantiate(projectilePrefab, newSpawnPosition, newRotationForPosition);
                projectileInstance.GetComponent<AttackCollisionDetection>().SetAttackType(attackTypesDictionary[attackName]);
                projectileInstance.tag = GameConstants.PLAYER_PROJECTILE_TAG;
                projectileInstance.gameObject.SetActive(true);
                isPlayerUsingRangedAttack = false;
            }
        }
        isPlayerUsingRangedAttack = false;
        isHealing = false;
    }

    private void SetUpAttackTypesDictionary()
    {
        foreach(AttackTypes attackType in allAttackTypes)
        {
            attackTypesDictionary.Add(attackType.AttackName, attackType);
        }
    }

    private void AddColliderAnimationEvent()
    {
        boxCollider.enabled = true;
    }

    private void RemoveColliderAnimationEvent()
    {
        boxCollider.enabled = false;
    }

}
