using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// TODO: Вот это тебе вообще не будет нужно в случае, если пуля будет сама наносить урон
public class BulletOnCollisionRegistration : MonoBehaviour
{
    public event Action bulletOnCollisionRegistration;

    private void OnCollisionEnter(Collision collision)
    {
        var damage = collision.gameObject.GetComponent<BulletDestroy>();

        if (damage != null)
        {
            Debug.Log("Take Damage!");
            bulletOnCollisionRegistration?.Invoke();
            
        }
    }
}
