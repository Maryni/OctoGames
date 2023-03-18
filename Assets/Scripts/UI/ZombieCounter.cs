using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    [SerializeField] private UIUpdater updater;
    private int count;

    public void AddCount()
    {
        count++;
        updater.UpdateValues(UIType.ZombieCounter, count);
    }
}
