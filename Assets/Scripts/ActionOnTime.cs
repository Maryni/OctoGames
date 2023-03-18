using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnTime : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float quickTime;
    
    public Action OnTimeAction;
    public Action OnTimeQuicklyAction;
    private Coroutine timerCoroutine;
    private Coroutine quickTimerCoroutine;

    public void StartTimer()
    {
        if (time > 0f && quickTime >0f)
        {
            timerCoroutine = StartCoroutine(Timer(time, OnTimeAction));
            quickTimerCoroutine = StartCoroutine(Timer(quickTime, OnTimeQuicklyAction));
        }
        else
        {
            Debug.LogError($"Time or quickTime from {this} = {time} | {quickTime}, it's cannot be under or equal 0");
        }
    }

    public void StopAllCoroutine()
    {
        StopCoroutine(timerCoroutine);
        StopCoroutine(quickTimerCoroutine);
    }

    private void StopCoroutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
        coroutine = null;
    }
    
    private IEnumerator Timer(float value, Action action)
    {
        yield return new WaitForSeconds(value);
        action?.Invoke();
        StartCoroutine(Timer(value, action));
    }

    private void OnDestroy()
    {
        OnTimeAction = null;
    }
}
