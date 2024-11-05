using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : SingletonBehavior<PlayerManager>
{
    public Text coinText;
    public static int numberCoin;

    // Start is called before the first frame update
    void Start()
    {
        numberCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoin();
    }
    void UpdateCoin()
    {
        coinText.text = "" +numberCoin;
    }
}
