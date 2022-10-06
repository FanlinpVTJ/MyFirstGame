using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : CollectableItem
{
    //������ �� �������
    //������ � ���� ���-�� ����

    [SerializeField]
    private int healthAmount;

    public override void Collect(ItemCollector collector)
    {
        var healthSystem = collector.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.TakeHeal(healthAmount);
            base.Collect(collector);
        }
    }
}

