using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : Singleton<SaveManager>
{
    PlayerData_Storage data = new PlayerData_Storage();
    public int currentCar;
    public int money;
    public bool[] carsUnblock = new bool[3] {true,false,false };
    public Text totalCoinsText;
    public static int totalCoins;

    private void Awake()
    {
        Load();
    }
    private void Update()
    {
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            money = data.money;
            currentCar = data.currentCar;
            carsUnblock = data.carsUnblock;

            if(data.carsUnblock == null)
                carsUnblock = new bool[3] { true, false, false };

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        data.money = money;
        data.currentCar = currentCar;
        data.carsUnblock = carsUnblock;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public int money;
    public int currentCar;
    public bool[] carsUnblock;
}
