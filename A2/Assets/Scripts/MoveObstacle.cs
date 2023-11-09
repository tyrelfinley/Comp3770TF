using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public int Move_Speed = 1;
    public int Direction = 1;

    void Update()
    {
        if (gameObject.transform.position.x < -4.5)
        {
            Direction = 1;
        }
        else if (gameObject.transform.position.x > 4.5) 
        {
            Direction = -1;
        }
        gameObject.transform.position = gameObject.transform.position + new Vector3(Move_Speed * Time.deltaTime * Direction, 0, 0);
    }
}
