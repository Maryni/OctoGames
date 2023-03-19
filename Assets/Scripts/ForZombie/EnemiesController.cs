using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private List<EnemyController> enemyControllers = new List<EnemyController>();

    public void ReloadAllEnemies()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            EnemyController enemy = transform.GetChild(i).GetComponent<EnemyController>();
            enemyControllers.Add(enemy);
        }

        foreach (EnemyController controller in enemyControllers)
        {
            controller.Reload();
        }
    }
}
