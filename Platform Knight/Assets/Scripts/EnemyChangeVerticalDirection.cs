using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeVerticalDirection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            GetComponentInParent<EnemyMovementVertical>().IsMovingUp = !GetComponentInParent<EnemyMovementVertical>().IsMovingUp;
        }
    }
}
