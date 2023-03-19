using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public Transform GetPlayerDestination()
    {
        return player.transform;
    }
}
