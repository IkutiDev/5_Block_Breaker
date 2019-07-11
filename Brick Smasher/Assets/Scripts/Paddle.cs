using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXPosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //Debug.Log(mouseXPosition);
        Vector2 paddlesPos = new Vector2(mouseXPosition, transform.position.y);
        transform.position = paddlesPos;
    }
}
