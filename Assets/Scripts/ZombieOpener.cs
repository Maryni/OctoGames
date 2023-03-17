using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieOpener : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    private Transform playerTransform;

    public void Open()
    {
        var zombie = pool.GetObject();
        zombie.SetActive(true);
        var agent = zombie.GetComponent<NavMeshAgent>();
        agent.destination = playerTransform.position;
    }
    
    public void SetPlayerTransform(Transform transform)
    {
        playerTransform = transform;
    }
}
