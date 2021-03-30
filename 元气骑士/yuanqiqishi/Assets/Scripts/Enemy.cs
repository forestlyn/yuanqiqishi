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
    public GameObject player;
    public GameObject EnemyBullet;

    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    
   
 

  
    

   

    void Start()
    {

    }


    void Update()
    {
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        
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
        }
        else if (timeVal > 3)
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (timeVal >= 6) timeVal = 0;
    }

    //发现玩家
    private void FindPlayer()
    {
        if (distance < 5)
        {
            transform.Translate(player.transform.position * Time.fixedDeltaTime * 1, Space.World);
        }
        if (distance < 2)
        {
            Attack();
        }
    }
    private void Attack()
    {
        if (timeVal >= 1)
        {
            Instantiate(EnemyBullet, transform.position, player.transform.rotation);
            timeVal = 0;
        }
            
    }
    
}
