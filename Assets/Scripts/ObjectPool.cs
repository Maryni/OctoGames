using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> listExamples;
    [SerializeField] private Transform transformPool;
    [SerializeField] private int countExamplesForSpawn;
    private List<GameObject> pool;
    private Transform playerTransform;

    public void Init()
    {
        for (int i = 0; i < countExamplesForSpawn; i++)
        {
            for (int j = 0; j < listExamples.Count; j++)
            { 
            var example = Instantiate(listExamples[j], transformPool);
            example.GetComponent<NavMeshAgent>().SetDestination(playerTransform.position);
            example.SetActive(false);
            }
        }
    }

    public void SetPlayerTransform(Transform transform)
    {
        playerTransform = transform;
    }
    
    private GameObject GetObject()
    {
        var current = pool.FirstOrDefault(x => x.activeSelf == false);
        if (current == null)
        {
            current = Instantiate(listExamples[Random.Range(0, listExamples.Count)], transformPool);
        }

        return current;
    }
}
