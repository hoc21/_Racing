using UnityEngine;

public class Winner : MonoBehaviour
{
    [SerializeField] private GameObject finishButton;
    private bool coinsSaved = false; // Flag to track if coins have been saved.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finishButton.SetActive(true);
            if (!coinsSaved) // Only save if not already saved.
            {
                PlayerManager.Instance.SavePlayerData();
                coinsSaved = true; // Mark coins as saved.
            }
        }
    }
}
