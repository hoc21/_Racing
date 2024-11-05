using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : Singleton<SaveManager>
{
    public int currentCar;
    public bool[] carsUnblock = new bool[3] { true, false, false };
    public Text totalCoinsText;
    public int totalCoins;

    private void Start()
    {
        Load();
        UpdateCoinsUI();
    }

    private void Update()
    {
        Debug.Log("Total Coins: " + totalCoins);
    }

    public void Load()
    {
        totalCoins = PlayerPrefs.GetInt("Coins", 0); 
        currentCar = PlayerPrefs.GetInt("CurrentCar", 0); 

        for (int i = 0; i < carsUnblock.Length; i++)
        {
            carsUnblock[i] = PlayerPrefs.GetInt($"CarUnlock_{i}", i == 0 ? 1 : 0) == 1; 
        }

        UpdateCoinsUI();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Coins", totalCoins); 
        PlayerPrefs.SetInt("CurrentCar", currentCar); 

        for (int i = 0; i < carsUnblock.Length; i++)
        {
            PlayerPrefs.SetInt($"CarUnlock_{i}", carsUnblock[i] ? 1 : 0);
        }
        PlayerPrefs.Save(); 
    }

    private void UpdateCoinsUI()
    {
        if (totalCoinsText != null)
        {
            totalCoinsText.text = totalCoins.ToString();
        }
        else
        {
            Debug.LogWarning("totalCoinsText is not assigned in the Inspector.");
        }
    }
}
