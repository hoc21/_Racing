using UnityEngine;
using UnityEngine.UI;

public class SpeedOmeter : MonoBehaviour
{
    public Rigidbody2D rb; // Rigidbody của xe
    public Text speedText; // UI hiển thị tốc độ
    private float speed; // Biến lưu tốc độ

    void Update()
    {
        if (rb != null && speedText != null)
        {
            speed = rb.velocity.magnitude * 3.6f; // Chuyển từ m/s sang km/h
            speedText.text =Mathf.Round(speed) + " km/h";
        }
    }
}
