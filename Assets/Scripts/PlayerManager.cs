using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : SingletonBehavior<PlayerManager>
{
    public static int numberOfCoin;
    public Text coinText;

    void Start()
    {
        ResetGameState();
    }

    void Update()
    {
        UpdateCoinText();
    }

    void ResetGameState()
    {
        numberOfCoin = 0;
        coinText.gameObject.SetActive(true);
    }

    void UpdateCoinText()
    {
        coinText.text = "Golds: " + numberOfCoin;
    }

    public void SavePlayerData()
    {
        int totalCoins = PlayerPrefs.GetInt("Coins", 0);
        totalCoins += numberOfCoin; 
        PlayerPrefs.SetInt("Coins", totalCoins);
        PlayerPrefs.Save();
    }
}
