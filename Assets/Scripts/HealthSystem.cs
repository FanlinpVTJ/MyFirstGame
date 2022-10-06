using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour 
{
    public event Action UnitDeath;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int currentMaxHealth;

    //присваиваем значение хп у юнита
    public HealthSystem(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    //дамаг, который просто приходит из вне
    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            Debug.Log($"Ранение на {damageAmount}");
            Debug.Log($"Сейчас осталось {currentHealth} HP");
        }
        if (currentHealth <= 0)
        {
            UnitDeath?.Invoke();
        }

            
    }
   
    //хил, который просто приходит из вне
    public void TakeHeal(int healAmount)
    {
        if (currentHealth < currentMaxHealth)
        {
            currentHealth += healAmount;
            Debug.Log($"Сейчас у тебя вот столько здоровья {currentHealth}");
        }
        if (currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
            Debug.Log($"Сейчас у тебя максимум здоровья {currentMaxHealth}");
        }
    }








    

    
   


    //// TODO: то же самое, пули могут быть разные и дамажить разное кол-во хп
    //// public void TakeDamage(int damageAmount)
    //// currentHealth -= damageAmount...
    //private void TakeDamage()
    //{
    //    if (currentHealth > 0)
    //    {
    //        // TODO: может получиться отрицательное здоровье
    //        currentHealth = currentHealth - 10;

    //        if(currentHealth <= 0)
    //        {
    //            Death();
    //        }
    //    }
    //    Debug.Log(currentHealth);
    //}

    //private void Death()
    //{
    //    if (currentHealth == 0)
    //    {
    //        // TODO: Врядли система здоровья должна определять поведение при умирании
    //        // она должна только сообщать владельцу здоровья, что ему пора помереть
    //        // А вот владелец должен себя уже уничтожить, если он посчитает это нужным
    //        // Может быть кейс, когда тебе надо сначала проиграть анимацию умирания, например
    //        Destroy(gameObject);
    //        //SceneManager.LoadScene(0);
    //    }
    //}

}
