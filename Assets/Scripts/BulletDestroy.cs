using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private float onScreenDelay = 1f;
    
    private void OnCollisionEnter(Collision collision)
    {
        var damage = collision.gameObject.GetComponent<HealthSystem>();

        if (damage != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, onScreenDelay);
        }
    }

}
