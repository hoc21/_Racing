using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerManager.numberCoin += 100;
            //ScoreMoney.scoreValue += 100;
            //SaveManager.instance.money += 100;
        }
    }
}
