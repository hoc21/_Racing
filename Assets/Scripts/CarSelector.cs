using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentCar;
    public GameObject[] cars;
    public CameraFollow cam;
    public DisplayDistanceText distance;
    void Start()
    {
        currentCar = PlayerPrefs.GetInt("CurrentCar", 0);
        foreach(GameObject car in cars)
            car.SetActive(false);

        cars[currentCar].SetActive(true);
        cam.SetTargetCam(cars[currentCar].transform);
        distance.SetTarget(cars[currentCar].transform);
    }


}
