using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelController : SingletonBehavior<FuelController>
{

    [SerializeField] private Image fuelImage;
    [SerializeField, Range(0.1f,5f)] private float fuelDrainSpeed = 1f;
    [SerializeField] private float maxFuelAmount = 100f;
    [SerializeField] private Gradient fuelGradient;

    private float currentFuelAmount;
   
    void Start()
    {
        currentFuelAmount = maxFuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        currentFuelAmount -= Time.deltaTime * fuelDrainSpeed;
        UpdateUI();

        if(currentFuelAmount <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    private void UpdateUI()
    {
        fuelImage.fillAmount = (currentFuelAmount / maxFuelAmount);
        fuelImage.color = fuelGradient.Evaluate(fuelImage.fillAmount);
    }

    public void FillFuel()
    {
        currentFuelAmount = maxFuelAmount;
        UpdateUI();
    }
}
