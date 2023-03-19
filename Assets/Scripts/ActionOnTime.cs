using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCoroutine
{
    None,
    TimerCoroutine,
    QuickTimeCoroutine
}

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
            if (timerCoroutine == null)
            {
                timerCoroutine = StartCoroutine(Timer(time, OnTimeAction, TypeCoroutine.TimerCoroutine));
            }

            if (quickTimerCoroutine == null)
            {
                quickTimerCoroutine = StartCoroutine(Timer(quickTime, OnTimeQuicklyAction, TypeCoroutine.QuickTimeCoroutine));
            }
        }
        else
        {
            Debug.LogError($"Time or quickTime from {this} = {time} | {quickTime}, it's cannot be under or equal 0");
        }
    }

    private void StartTimer(TypeCoroutine typeCoroutine)
    {
        switch (typeCoroutine)
        {
            case TypeCoroutine.TimerCoroutine:
                timerCoroutine = StartCoroutine(Timer(time, OnTimeAction));
                break;
            case TypeCoroutine.QuickTimeCoroutine:
                quickTimerCoroutine = StartCoroutine(Timer(quickTime, OnTimeQuicklyAction));
                break;
        }
    }

    public void StopAllCoroutines()
    {
        StopMyCoroutine(timerCoroutine);
        StopMyCoroutine(quickTimerCoroutine);
    }

    private void StopMyCoroutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
        coroutine = null;
    }

    private void RestartCoroutine(TypeCoroutine typeCoroutine)
    {
        switch (typeCoroutine)
        {
            case TypeCoroutine.TimerCoroutine: 
                StopMyCoroutine(timerCoroutine);
                StartTimer(TypeCoroutine.TimerCoroutine);
                break;
            case TypeCoroutine.QuickTimeCoroutine:
                StopMyCoroutine(quickTimerCoroutine);
                StartTimer(TypeCoroutine.QuickTimeCoroutine);
                break;
            default:
                break;
        }
    }
    
    private IEnumerator Timer(float value, Action action, TypeCoroutine typeCoroutine = TypeCoroutine.None)
    {
        yield return new WaitForSeconds(value);
        action?.Invoke();
        if (typeCoroutine == TypeCoroutine.TimerCoroutine)
        {
            RestartCoroutine(typeCoroutine);  
        }

        if (typeCoroutine == TypeCoroutine.QuickTimeCoroutine)
        {
            quickTimerCoroutine = StartCoroutine(Timer(value, action, TypeCoroutine.QuickTimeCoroutine));
        }
    }

    private void OnDisable()
    {
        //OnTimeAction = null;
        //OnTimeQuicklyAction = null;
    }
}
