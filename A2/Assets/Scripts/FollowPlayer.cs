using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position + new Vector3(0, 2, -10);
        transform.LookAt(player.transform.position);
    }
}
