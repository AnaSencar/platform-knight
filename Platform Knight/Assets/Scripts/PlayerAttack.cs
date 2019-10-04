using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AttackTypes[] attackTypes;

    private Animator animator;
    private BoxCollider2D boxCollider;
    private AttackTypes currentAttackType;
    private int attackTypeIndex;
    private AttackCollisionDetection playerAC;

    private bool isPlayerUsingRangedAttack = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        playerAC = GetComponentInChildren<AttackCollisionDetection>();
        boxCollider.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Attack("Attack"));
            detectAttackType("Attack");
            currentAttackType = attackTypes[attackTypeIndex];
            playerAC.AttackType = currentAttackType;

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isPlayerUsingRangedAttack = true;
            StartCoroutine(Attack("CastAttack"));
            detectAttackType("Attack2");
            currentAttackType = attackTypes[attackTypeIndex];
            playerAC.AttackType = currentAttackType;
        }
    }

    private IEnumerator Attack(string attackName)
    {
        animator.SetTrigger(attackName);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        if (isPlayerUsingRangedAttack)
        {
            Vector3 newSpawnPosition = projectileSpawnLocation.position;
            Quaternion newRotationForPosition = projectileSpawnLocation.rotation;
            if (transform.localScale.x < 0)
            {
                newRotationForPosition.eulerAngles = new Vector3(0f, 0f, 180f);
            }
            Instantiate(projectilePrefab, newSpawnPosition, newRotationForPosition);
            isPlayerUsingRangedAttack = false;
        }
    }

    private void detectAttackType(string attackName)
    {
        for (int i = 0; i < attackTypes.Length; i++)
        {
            if(attackTypes[i].name == attackName)
            {
                attackTypeIndex = i;
                i = attackTypes.Length + 1;
            }
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
