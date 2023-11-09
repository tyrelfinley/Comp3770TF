using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody body;
    public int Walk_Speed = 10;
    public int Jump_Power = 200;
    public int Jump_Amount = 2;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jump_Amount > 0)
        {
            body.AddForce(transform.up * Jump_Power);
            Jump_Amount -= 1;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.forward * Walk_Speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Jump_Amount = 2;
    }
}
