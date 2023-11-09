using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 Rotate_Speed = new Vector3(30, 15, 45);
    public Vector3 Rotate_Velocity = new Vector3(0, 0, 0);

    void Update()
    {
        Rotate_Velocity = Rotate_Speed * Time.deltaTime;
        gameObject.transform.Rotate(Rotate_Velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
