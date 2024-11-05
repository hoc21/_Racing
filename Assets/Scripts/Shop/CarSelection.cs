using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [Header ("Navigation Buttons")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text priceText;

    [Header("Car Attributes")]
    private int currentCar;
    [SerializeField]private int[] carPrices;

    void Start()
    {
        //currentCar = SaveManager.Instance.currentCar;
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
        if (SaveManager.Instance.carsUnblock[currentCar])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = carPrices[currentCar] + "$";
        }
    }

    private void Update()
    {
        //check if we have enough money
        //if (buy.gameObject.activeInHierarchy)
        //{
        //    buy.interactable = (SaveManager.Instance.money >= carPrices[currentCar]);
        //}
        Debug.Log(SaveManager.totalCoins);
        Debug.Log(SaveManager.Instance.currentCar);
    }

    public void ChangeCar(int change)
    {
        currentCar += change;

        if(currentCar > transform.childCount - 1)
            currentCar = 0;
        else if(currentCar < 0)
            currentCar = transform.childCount - 1;

        SaveManager.Instance.currentCar = currentCar;
        SaveManager.Instance.Save();

        SelectCar(currentCar);
    }

    public void BuyCar()
    {
        SaveManager.Instance.money -= carPrices[currentCar];
        SaveManager.Instance.carsUnblock[currentCar] = true;
        SaveManager.Instance.Save();
        UpdateUI();
    }
}
