using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    //引用
    public Transform player;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        Vector3 a = player.position - transform.position;
        transform.eulerAngles = new Vector3(0, 0, 90);
    }
}
