using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //属性值
    public float moveSpeed;
    public float timeVal = 5;
    public float lifeValue;

    public float distance;
    //引用
    public Transform player;
    public GameObject EnemyBullet;
    
    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.position);
        
        if (distance >= 5) Move();
        FindPlayer();
        timeVal += Time.fixedDeltaTime;
        
    }
    public void Die()
    {
        lifeValue -= 3;
        if (lifeValue <= 0)
            Destroy(gameObject);
    }

    //移动
    private void Move()
    {
        if (timeVal <= 3)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (timeVal > 3)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (timeVal >= 6) timeVal = 0;
    }

    //发现玩家
    private void FindPlayer()
    {
        if (distance < 8)
        {
            Vector3 a = player.transform.position - transform.position;
            transform.Translate(a * Time.fixedDeltaTime * 1, Space.World);
        }
        if (distance < 4)
        {
            Attack();
        }
    }

    //攻击
    private void Attack()
    {
        if (timeVal >= 3)
        {
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            timeVal = 0;
        }            
    }
    
}
