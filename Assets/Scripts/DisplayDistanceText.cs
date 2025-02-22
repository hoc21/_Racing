using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDistanceText : MonoBehaviour
{
    [SerializeField] private Text distanceText;
    [SerializeField] private Transform playerTrans;

    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = playerTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = (Vector2)playerTrans.position - startPosition;
        distance.y = 0f;

        if(distance.x <0)
        {
            distance.x = 0;
        }
        distanceText.text = distance.x.ToString("F0") + "m"; 
    }
    public void SetTarget(Transform target)
    {
        playerTrans = target;
    }
}
