using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    //属性
    public float moveSpeed;
    public bool isPlayerBullet;
    public Vector3 a;
    
    //引用
    public GameObject BrokenBullet;
    private Transform Player;
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        a = Player.position - transform.position;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPlayerBullet)
        {
            transform.Translate(a * moveSpeed * Time.fixedDeltaTime, Space.World);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                if (!isPlayerBullet)
                {
                    Instantiate(BrokenBullet, transform.position, transform.rotation);
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Enemy":
                if (isPlayerBullet)
                {
                    Instantiate(BrokenBullet, transform.position, transform.rotation);
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Box":
                Instantiate(BrokenBullet, transform.position, transform.rotation);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                Instantiate(BrokenBullet, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
