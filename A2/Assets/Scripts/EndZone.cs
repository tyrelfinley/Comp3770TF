using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer>();
        gameObjectRenderer.material.color = Color.green;
    }
}
