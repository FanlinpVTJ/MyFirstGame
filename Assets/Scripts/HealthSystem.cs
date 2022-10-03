using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private ItemCollector itemCollector;

    [SerializeField]
    private int maxHelth = 100;
    private int currentHealth;

    void OnEnable()
    {
        itemCollector.ItemCollected += TakeHeal;
    }
    void OnDisable()
    {
        itemCollector.ItemCollected -= TakeHeal;
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

    private void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;

            if(currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        if (currentHealth == 0)
        {
            Destroy(gameObject);
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
