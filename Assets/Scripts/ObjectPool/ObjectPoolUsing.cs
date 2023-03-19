using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolUsing : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private PlayerFinder playerFinder;
    [SerializeField] private ZombieOpener zombieOpener;
    [SerializeField] private ActionOnTime actionOnTime;


    public void StopAll()
    {
        actionOnTime.StopAllCoroutines();
        List<GameObject> actives = objectPool.GetAllActiveObjects();
        foreach (GameObject localGameObject in actives)
        {
            localGameObject.GetComponent<EnemyController>().Stop();
            localGameObject.SetActive(false);
        }
    }
    
    private void Start()
    {
        zombieOpener.SetPlayerTransform(playerFinder.GetPlayerDestination());
        objectPool.Init();
        
        actionOnTime.OnTimeAction += () => zombieOpener.Open();
        actionOnTime.OnTimeQuicklyAction += () => zombieOpener.Open(true);
        actionOnTime.StartTimer();
    }
    
}
