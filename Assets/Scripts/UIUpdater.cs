using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIType
{
    None,
    ZombieCounter
}
public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Text zombieCount;

    public void UpdateValues(UIType type, int value)
    {
        switch (type)
        {
            case UIType.ZombieCounter: zombieCount.text = value.ToString(); break;
            default: break;
        }
    }
}
