using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //引用
    private Transform Player;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Player.eulerAngles == new Vector3(0, 0, 0))
        {
            transform.position = Player.position + new Vector3(0.15f, -0.3f, 0);
        }
        else
        {
            transform.position = Player.position + new Vector3(-0.15f, -0.3f, 0);
        }
    }
}
