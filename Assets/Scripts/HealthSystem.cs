using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    // TODO: Система здоровья скорее всего не должна знать ничего про собирание штук на сцене
    [SerializeField]
    private ItemCollector itemCollector;

    // TODO: Система здоровья точно должна знать что-то про пули?
    // А если у нас появится, к примеру, лужа с кислотой?
    [SerializeField]
    private BulletOnCollisionRegistration bulletOnCollisionRegistration;

    [SerializeField]
    private int maxHelth = 100;
    private int currentHealth;

    void OnEnable()
    {
        itemCollector.ItemCollected += TakeHeal;
        bulletOnCollisionRegistration.bulletOnCollisionRegistration += TakeDamage;
    }
    void OnDisable()
    {
        itemCollector.ItemCollected -= TakeHeal;
        bulletOnCollisionRegistration.bulletOnCollisionRegistration -= TakeDamage;
    }
        
    // TODO: А если аптечки могут быть разного размера хп? Одна дает 5 хп, а другая 10
    // ктото извне должен сообщить ей, сколько хп он ей даст
    // public void TakeHeal(int healAmount)
    // currentHealth += healAmount
    private void TakeHeal()
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth + 10;

            if(currentHealth > maxHelth)
            {
                currentHealth = maxHelth;
            }
        }
        Debug.Log(currentHealth);
    }

    // TODO: то же самое, пули могут быть разные и дамажить разное кол-во хп
    // public void TakeDamage(int damageAmount)
    // currentHealth -= damageAmount...
    private void TakeDamage()
    {
        if (currentHealth > 0)
        {
            // TODO: может получиться отрицательное здоровье
            currentHealth = currentHealth - 10;

            if(currentHealth <= 0)
            {
                Death();
            }
        }
        Debug.Log(currentHealth);
    }

    private void Death()
    {
        if (currentHealth == 0)
        {
            // TODO: Врядли система здоровья должна определять поведение при умирании
            // она должна только сообщать владельцу здоровья, что ему пора помереть
            // А вот владелец должен себя уже уничтожить, если он посчитает это нужным
            // Может быть кейс, когда тебе надо сначала проиграть анимацию умирания, например
            Destroy(gameObject);
            //SceneManager.LoadScene(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHelth/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
