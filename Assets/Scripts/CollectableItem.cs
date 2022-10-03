using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public void Collect()
    {
       Destroy(gameObject);
    }
}
