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
    
    private List<GameObject> pool = new List<GameObject>();
    

    public void Init()
    {
        for (int i = 0; i < countExamplesForSpawn; i++)
        {
            for (int j = 0; j < listExamples.Count; j++)
            { 
            var example = Instantiate(listExamples[j], transformPool);
            pool.Add(example);
            example.SetActive(false);
            }
        }
    }

    public GameObject GetObject()
    {
        var findedObject = pool.FirstOrDefault(x => !x.activeSelf);
        if (findedObject == null)
        {
            var newObject = Instantiate(listExamples[Random.Range(0, listExamples.Count)], transformPool);
            newObject.SetActive(false);
            return newObject;
        }

        return findedObject;
    }
}
