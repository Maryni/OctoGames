using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolUsing : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private PlayerFinder playerFinder;

    private void Start()
    {
        objectPool.SetPlayerTransform(playerFinder.GetPlayerDestination());
        objectPool.Init();
    }
}
