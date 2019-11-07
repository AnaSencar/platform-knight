using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreenHandler : MonoBehaviour
{
    private GameObject upgradeScreen;
    private bool isPaused = false;

    private void Awake()
    {
        upgradeScreen = GameObject.FindGameObjectWithTag(GameConstants.UPGRADE_SCREEN_TAG);
        upgradeScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            OpenOrCloseUpgradeScreen();
            //StopOrStartAllEnemyMovementAndAttacks();
        }
    }

    private void OpenOrCloseUpgradeScreen()
    {
        upgradeScreen.gameObject.SetActive(!upgradeScreen.gameObject.activeSelf);
    }

    private void StopOrStartAllEnemyMovementAndAttacks()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyAttack>().enabled = !enemy.GetComponent<EnemyAttack>().enabled;
        }
    }

}
