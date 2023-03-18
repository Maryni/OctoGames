using System;
using System.Collections;
using System.Collections.Generic;
using Opsive.UltimateCharacterController.Traits;
using Opsive.UltimateCharacterController.Traits.Damage;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float rateDamage;
    
    //private Action OnDealDamageAction;
    private GameObject gameObjectWhoTakeDamage;
    private Coroutine takeDamageCoroutine;
    
    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.layer == 31)
        {
            Health healthPlayer = collisionInfo.gameObject.GetComponent<Health>();
            if (gameObjectWhoTakeDamage == null)
            {
                gameObjectWhoTakeDamage = collisionInfo.gameObject;
                
                if (takeDamageCoroutine == null) 
                {
                    StartDamageCoroutine(rateDamage, damage, healthPlayer);
                }
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == gameObjectWhoTakeDamage)
        {
            gameObjectWhoTakeDamage = null;
            StopDamageCoroutine();
        }
    }
    
    private void StartDamageCoroutine(float rate, float damage, Health health)
    {
        takeDamageCoroutine = StartCoroutine(TakeDamage(rate, damage, health));
    }
    
    private IEnumerator TakeDamage(float rate, float damage, Health health)
    {
        yield return rate;
        health.Damage(damage);
        TakeDamage(rate, damage, health);
    }

    private void StopDamageCoroutine()
    {
        StopCoroutine(takeDamageCoroutine);
        takeDamageCoroutine = null;
    }
}
