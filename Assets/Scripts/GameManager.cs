using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using System;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int maxItemCountToWin = 4;

    [SerializeField]
    private ItemCollector itemCollector;

    private int collectedItemsCount = 0;


    void OnEnable()
    {
        itemCollector.ItemCollected += ChangeItemCount;
    }
    void OnDisable()
    {
        itemCollector.ItemCollected -= ChangeItemCount;
    }

    private void ChangeItemCount()
    {
        collectedItemsCount++;
        Debug.Log($"Item collected! You have {collectedItemsCount}");
        CheckPlayerWin();
    }
    private void CheckPlayerWin()
    {
        if (collectedItemsCount == maxItemCountToWin)
        {
            Debug.Log("You WIN!");
            SceneManager.LoadScene(0);
        }
    }
}
