using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: вот это как раз класс, который описывает саму пулю, а не только её уничтожение
// В нем можно написать логику, как она должна дамажить, куда дамажить, сколько и как 
// она себя после всего этого уничтожает
// public class Bullet...
public class BulletBehaviour : MonoBehaviour
{
    // TODO:
    [SerializeField]
    private int bulletDamage;
    
    private float onScreenDelay = 1f;
    
    private void OnCollisionEnter(Collision collision)
    {
        var healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (healthSystem != null)
        {
            healthSystem.TakeDamage(bulletDamage);
            Destroy(gameObject, 0f);
            
        }
        else
        {
            Destroy(gameObject, onScreenDelay);
        }
    }

}
