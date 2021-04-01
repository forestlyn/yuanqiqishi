using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //属性值
    public float moveSpeed;
    public float timeVal = 5;
    public float AttackTime;
    public float lifeValue;
    public bool isEnemy1;
    
    public float distance;

    //引用
    public Transform player;
    public GameObject EnemyBullet;
    public Animator anim;
    
    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }

   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
       
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance >= 8) Move();
        FindPlayer();
        timeVal += Time.fixedDeltaTime;
        
    }
    public void Die()
    {
        lifeValue -= 3;
        if (lifeValue <= 0)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject, 1f);
        }     
    }

    //移动
    private void Move()
    {
        anim.SetFloat("running", 1);
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
        Vector3 a = player.transform.position - transform.position;
        if (distance < 8 && distance >= 4)
        {
            anim.SetFloat("running", 1);
            transform.Translate(a * Time.fixedDeltaTime * 1, Space.World);
        }
        if (distance < 4)
        {
            anim.SetFloat("running", 0);
            if (isEnemy1) Attack1();
            else Attack2();
        }
        if (a.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (a.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    //攻击
    private void Attack2()
    {
        if (timeVal >= AttackTime && lifeValue > 0)
        {
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            timeVal = 0;
        }            
    }
    private void Attack1()
    {
        if (timeVal >= AttackTime && lifeValue > 0)
        {
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            timeVal = 0;
        }
    }

}
