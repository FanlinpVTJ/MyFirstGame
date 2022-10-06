using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class UnitDestroy : MonoBehaviour
{
    /*Хотелось бы избавиться от этого поля нахер и получать инфу о health system сразу напрямую, 
     * без запихиваний gameObjecta сюда в инспекторе, но я тупенький*/
    [SerializeField]
    private HealthSystem healthSystem;

   
    void OnEnable()
    {
        healthSystem.UnitDeath += Destroy;
    }
    void OnDisable()
    {
        healthSystem.UnitDeath -= Destroy;
    }

    private void Destroy()
    {
       Destroy(gameObject);
    }
}
