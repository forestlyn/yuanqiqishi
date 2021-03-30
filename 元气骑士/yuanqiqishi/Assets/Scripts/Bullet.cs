using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //属性
    public float moveSpeed = 4;
    public bool isPlayerBullet;
    // Start is called before the first frame update
    //引用
    public GameObject BrokenBullet;
    public GameObject Player;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 a;
        a = Player.transform.position - transform.position;
        if (!isPlayerBullet)
        {
            transform.Translate(a * 1 * Time.fixedDeltaTime, Space.World);
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
