using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeDirection : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            transform.parent.localScale = new Vector2(-Mathf.Sign(gameObject.GetComponentInParent<Rigidbody2D>().velocity.x), 1f);
        }
    }
}
