using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private GameObject projectilePrefab;

    private Animator animator;
    private BoxCollider2D boxCollider;
    private PlayerStats playerStats;
    private float facingDirectionAtTimeOfAttack;

    private bool isPlayerUsingRangedAttack = false;

    public float FacingDirectionAtTimeOfAttack
    {
        get
        {
            return facingDirectionAtTimeOfAttack;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        playerStats = GetComponent<PlayerStats>();
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
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isPlayerUsingRangedAttack = true;
            StartCoroutine(Attack("CastAttack"));
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
            facingDirectionAtTimeOfAttack = transform.localScale.x; 
            Instantiate(projectilePrefab, newSpawnPosition, newRotationForPosition);
            isPlayerUsingRangedAttack = false;
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
