using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    // Update is called once per frame
    void Update()
    {
        float mouseXPosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlesPos = new Vector2(transform.position.x, transform.position.y);
        paddlesPos.x = Mathf.Clamp(mouseXPosition,minX,maxX);
        transform.position = paddlesPos;
    }
}
