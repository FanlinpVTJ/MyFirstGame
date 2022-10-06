using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public virtual void Collect(ItemCollector collector)
    {
       Destroy(gameObject);
    }
        
}
