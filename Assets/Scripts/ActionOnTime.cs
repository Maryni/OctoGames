using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnTime : MonoBehaviour
{
    [SerializeField] private float time;
    public Action OnTimeAction;
    private Coroutine timerCoroutine;

    public void StartTimer()
    {
        if (time > 0f)
        {
            timerCoroutine = StartCoroutine(Timer(time));
        }
        else
        {
            Debug.LogError($"Time from {this} = {time}, it's cannot be under or equal 0");
        }
    }

    private void StopCoroutine()
    {
        StopCoroutine(timerCoroutine);
        timerCoroutine = null;
    }
    
    private IEnumerator Timer(float value)
    {
        yield return new WaitForSeconds(value);
        OnTimeAction?.Invoke();
        StartCoroutine(Timer(value));
    }

    private void OnDestroy()
    {
        OnTimeAction = null;
    }
}
