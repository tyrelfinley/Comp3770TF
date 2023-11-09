using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIt : MonoBehaviour
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
        if (gameObject.transform.position.x >= 3 || gameObject.transform.position.x <= -3)
        {
            speed = speed * -1;
        }
        velocity = speed * Time.deltaTime;
        gameObject.transform.Translate(velocity, 0, 0);
    }

}
