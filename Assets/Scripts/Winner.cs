using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Winner : MonoBehaviour
{

    [SerializeField] private GameObject finishButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finishButton.SetActive(true);         
        }
    }
}

