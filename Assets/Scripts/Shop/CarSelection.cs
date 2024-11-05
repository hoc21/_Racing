using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : SingletonBehavior<CarSelection>
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Text priceText;

    [Header("Car Attributes")]
    public int currentCar;
    [SerializeField] private int[] carPrices;

    void Start()
    {
        currentCar = SaveManager.Instance.currentCar;
        SelectCar(currentCar);
    }

    private void SelectCar(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        bool isUnlocked = SaveManager.Instance.carsUnblock[currentCar];

        playButton.gameObject.SetActive(isUnlocked);
        buyButton.gameObject.SetActive(!isUnlocked);

        if (!isUnlocked)
        {
            priceText.text = carPrices[currentCar] + "$";
            buyButton.interactable = SaveManager.Instance.totalCoins >= carPrices[currentCar];
        }
    }

    public void ChangeCar(int change)
    {
        currentCar += change;

        if (currentCar > transform.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = transform.childCount - 1;

        SaveManager.Instance.currentCar = currentCar;
        SaveManager.Instance.Save();

        SelectCar(currentCar);
    }

    public void BuyCar()
    {
        if (SaveManager.Instance.totalCoins >= carPrices[currentCar])
        {
            SaveManager.Instance.totalCoins -= carPrices[currentCar];
            SaveManager.Instance.carsUnblock[currentCar] = true;
            SaveManager.Instance.Save();
            UpdateUI();
        }
    }
}
