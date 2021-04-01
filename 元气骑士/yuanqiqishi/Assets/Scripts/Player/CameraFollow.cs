
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        offset = new Vector3(0, 0, -5);
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}

