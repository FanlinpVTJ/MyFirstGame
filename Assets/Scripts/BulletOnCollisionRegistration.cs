using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
