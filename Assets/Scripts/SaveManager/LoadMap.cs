using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMap : MonoBehaviour
{
    public void ChangeScene(string Scene)
    {

        if (!string.IsNullOrEmpty(Scene))
        {
            SceneManager.LoadScene(Scene);
        }
        else
        {
            Debug.LogWarning("Tên scene không hợp lệ.");
        }
    }
}
