using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: вот это как раз класс, который описывает саму пулю, а не только её уничтожение
// В нем можно написать логику, как она должна дамажить, куда дамажить, сколько и как 
// она себя после всего этого уничтожает
// public class Bullet...
public class BulletDestroy : MonoBehaviour
{
    // TODO:
    // [SerializeField]
    // private int bulletDamage;
    
    private float onScreenDelay = 1f;
    
    private void OnCollisionEnter(Collision collision)
    {
        // это бы назвать health или healthSystem тогда уж, а не damage
        var damage = collision.gameObject.GetComponent<HealthSystem>();

        if (damage != null)
        {
            // То, что может наносить урон может знать про то, куда его наносаить
            // это более конкретная реализация взаимодействия с системой здоровья
            // а вот сама система здоровья должна только знать о том, что она есть и 
            // в нее можно продамажить
            
            // TODO:
            // healthSystem.TakeDamage(bulletDamage)
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, onScreenDelay);
        }
    }

}
