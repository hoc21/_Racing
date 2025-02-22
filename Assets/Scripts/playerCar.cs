using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCar : MonoBehaviour
{
    public GameObject[] carModels;
    private int selectedCar;
    // Start is called before the first frame update
    void Start()
    {
        selectedCar = PlayerPrefs.GetInt("CurrentCar", 0);
        foreach (GameObject car in carModels)
            car.SetActive(false);
        if (selectedCar >= 0 && selectedCar < carModels.Length)
        {
            carModels[selectedCar].SetActive(true);
        }
    }

    
}
