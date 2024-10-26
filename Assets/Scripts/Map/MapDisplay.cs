using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Text mapName;
    [SerializeField] private Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockIcon;

    public void DisplayMap(Map map)
    {
        mapName.text = map.mapName;
        mapName.color = map.nameColor;
        mapDescription.text = map.mapDescription;
        mapImage.sprite = map.mapImage;

        bool mapUnblock = PlayerPrefs.GetInt("currentScene",0) >= map.mapIndex;
        lockIcon.SetActive(!mapUnblock);
        playButton.interactable = mapUnblock;
        if (mapUnblock )
            mapImage.color = Color.white;
        else
            mapImage.color = Color.gray;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => SceneManager.LoadScene(map.sceneToLoad.name));
    }

}
