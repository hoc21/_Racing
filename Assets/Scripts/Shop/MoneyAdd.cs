using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyAdd : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SaveManager.Instance.money += 100;
            SaveManager.Instance.Save();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            SaveManager.Instance.money -= 100;
            SaveManager.Instance.Save();
        }           
    }
}
