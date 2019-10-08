using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    [SerializeField] private float pushForce;
    [SerializeField] private Vector2 pushDirection;
    [SerializeField] private int damageToDeal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameConstants.PLAYER_TAG)
        {
            pushDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<PlayerMovement>().PushPlayer(pushDirection, pushForce);
            collision.gameObject.GetComponent<Health>().TakeDamage(damageToDeal);
        }
    }
}
