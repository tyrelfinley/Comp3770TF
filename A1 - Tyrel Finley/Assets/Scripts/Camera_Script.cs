using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    public float Camera_Speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(5, 8, -12);
        gameObject.transform.Rotate(30, -25, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Camera_Speed * Time.deltaTime * gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Camera_Speed * Time.deltaTime * -gameObject.transform.forward;
        }
    }
}
