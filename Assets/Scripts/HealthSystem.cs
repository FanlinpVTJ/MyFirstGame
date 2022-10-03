using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private ItemCollector itemCollector;

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

    private void TakeDamage()
    {
        if (currentHealth > 0)
        {
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
