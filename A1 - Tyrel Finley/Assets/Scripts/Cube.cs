using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int speed = 1;
    public float velocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, velocity, 0);
    }

   void FixedUpdate()
   {
        
        velocity = speed * Time.fixedDeltaTime;
   }
}
