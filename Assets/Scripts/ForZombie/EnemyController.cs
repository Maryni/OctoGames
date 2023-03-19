using System.Collections;
using System.Collections.Generic;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyDealDamage enemyDealDamage;
    [SerializeField] private AttributeManager attributeManager;

    public void Stop()
    {
        enemyDealDamage.StopDamageCoroutine();
    }

    public void Reload()
    {
        attributeManager.Attributes[0].Value = attributeManager.Attributes[0].MaxValue;
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
    }
}
