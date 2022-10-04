using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    // TODO: делаем тут virtual и добавляем в параметр метода
    // коллектор, который собрал объект
    // это нужно, чтобы потом можно было найти на этом объекте HealthSystem 
    // и сказать ей, что мы хотим отхилять её на определенное кол-во хп
    // в классе HealthCollectable
    public virtual void Collect(ItemCollector collector)
    {
       Destroy(gameObject);
    }
    
    // P.S.
    // Да, у нас в итоге все равно коллектабл знает про коллектора,
    // но это хотя-бы свзяанные друг с другом вещи, а вот 
    // ItemCollector и HealthSystem не особо должны быть свзяаны в классе HealthSystem, как у тебя сейчас
    // // (сейчас у тебя в системе здоровья прямая ссылка на коллектор)
}

// TODO: можно в отдельном скрипте написать наследника
// и переопределить поведение при Collect().
// таким образом никто в игре не будет знать про существование аптечек,
// аптечки сами будут хилять
// при этом коллектор не будет значть про аптечки тоже, он будет работать с CollectableItem
// аптечка - это лишь частный случай CollectableItem, который добавляет хп
// в будущем ты сможешь так же написать собираемые патроны, просто переопределив
// Collect() и в нем написав логику "найти на объекте оружие и добавить в него патронов"

// public class HealthCollectable : CollectableItem
// {
//     [SerializeField]
//     private int healthAmount;
//
//     public override void Collect(ItemCollector collector)
//     {
//         var healthSysten = collector.GetComponent<HealthSystem>();
//         if (healthSysten != null)
//         {
//             healthSysten.TakeHeal(healthAmount);
//         }
//         
           // не забыть вызвать базовый Collect, т.к. там у нас написано Destroy(gameObject)
//         base.Collect(collector);
//     }
// }
