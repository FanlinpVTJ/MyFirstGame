using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class UnitDestroy : MonoBehaviour
{
    /*�������� �� ���������� �� ����� ���� ����� � �������� ���� � health system ����� ��������, 
     * ��� ����������� gameObjecta ���� � ����������, �� � ���������*/
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
