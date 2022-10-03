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
        }
    }


    //[SerializeField]
    //private TextMeshProUGUI healthText;

    //private bool showWinScreen = false;
    //private int maxItem = 4;
    
    //public string labelText = "Collect all 4 items and win your freedom!";
    //public int Item
    //{
    //    get { return collectedItemsCount; }
    //    set { CollectItem(value); }
    //}

    //private int playerHP = 10;

    //private void Start()
    //{
    //    SetHealth(playerHP);
    //}

    //public int HP
    //{
    //    get { return playerHP; }
    //    set { SetHealth(value); }
    //}

    //private void SetHealth(int newHealth)
    //{
    //    playerHP = newHealth; 
    //    Debug.Log($"HP: {playerHP}");
    //    healthText.text = $"PlayerHP: {HP}";
    //}

    //private void CollectItem(int item)
    //{
    //    collectedItemsCount = item;
    //    Debug.Log($"Items: {collectedItemsCount}");
    //    if (collectedItemsCount == maxItem)
    //    {
    //        labelText = "”се, молодец ";
    //        showWinScreen = true;
    //        Time.timeScale = 0;

    //    }
    //    else
    //    {
    //        labelText = "»щи есчо, у т€ толька" + (maxItem - collectedItemsCount);
    //    }
    //}

    

}
