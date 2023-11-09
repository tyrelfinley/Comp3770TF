using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIt : MonoBehaviour
{
    public Vector3 Rotate_Speed = new Vector3 (30, 60, 90);
    public Vector3 Rotate_Velocity = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate_Velocity = Rotate_Speed * Time.deltaTime;
        gameObject.transform.Rotate(Rotate_Velocity);
    }
}
