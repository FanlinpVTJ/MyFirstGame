using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class ItemCollector : MonoBehaviour
{
    public event Action ItemCollected;
        
    private void OnCollisionEnter(Collision collision)
    {
        var collectable = collision.gameObject.GetComponent<CollectableItem>();

        if (collectable != null)
        {
            //Debug.Log("Item collected!");
            ItemCollected?.Invoke();
            
            // TODO: а тут после изменений в CollectableItem добавить ссылку на себя,
            // потому что именно этот коллектор собрал коллектабл
            // и аптечка будет искать healthSystem на этом gameObject
            collectable.Collect(this);
        }
    }
}