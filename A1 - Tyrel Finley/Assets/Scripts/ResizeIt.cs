using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeIT : MonoBehaviour
{
    public int Direction = -1;
    public int Max_Size = 4;
    public int Min_Size = 1;
    public Vector3 Speed = new Vector3(1, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (gameObject.transform.localScale.x <= Min_Size)
        {
            Direction = Direction * -1;
        }
      else if (gameObject.transform.localScale.x >= Max_Size)
        {
            Direction = Direction * -1;
        }
        gameObject.transform.localScale += Speed * Time.deltaTime * Direction;
    }
}
