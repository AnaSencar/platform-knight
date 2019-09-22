using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeCrawlerDirection : MonoBehaviour
{
    [SerializeField] private float degreesToRotate = 90f;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (GetComponentInParent<EnemyCrawlerMovement>().IsWalkingright)
            {
                transform.parent.Rotate(0f, 0f, -degreesToRotate);
            }
            else
            {
                transform.parent.Rotate(0f, 0f, degreesToRotate);
            }
        }
    }

}
