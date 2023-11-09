using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    GameObject player;
    Vector3 Start_Point = new Vector3 (0, 1, 0);
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        player.transform.position = Start_Point;
    }
}
