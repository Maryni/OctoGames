using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieOpener : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    private Transform playerTransform;

    public void Open(bool isActiveObject = false)
    {
        GameObject zombie;
        if (!isActiveObject)
        {
            zombie = pool.GetObject();
        }
        else
        {
            zombie = pool.GetActiveObject();
        }

        if (zombie != null)
        {
            var agent = zombie.GetComponent<NavMeshAgent>();
            agent.destination = playerTransform.position;
        }
    }

    public void SetPlayerTransform(Transform transform)
    {
        playerTransform = transform;
    }
}
