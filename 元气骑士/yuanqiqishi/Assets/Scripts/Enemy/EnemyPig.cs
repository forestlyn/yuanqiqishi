using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPig : MonoBehaviour
{
    //属性值
    public float moveSpeed;
    public float timeVal = 5;
    public float AttackTime;
    public float lifeValue;

    public float distance;

    //引用
    public Transform player;
    public Animator anim;

    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        if (!PlayerManager.Instance.isDefeat)
        {
            distance = Vector3.Distance(transform.position, player.position);
            if (distance >= 8 && lifeValue > 0) Move();
            if (lifeValue > 0) FindPlayer();
        }
       
    }


    public void Die()
    {
        lifeValue -= Player.Instance.playerATK;
        if (lifeValue <= 0)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject, 1f);
            PlayerManager.Instance.Bullet = (10 + PlayerManager.Instance.Bullet) > 180 ? 180 : (10 + PlayerManager.Instance.Bullet);
        }
    }

    //发现玩家前移动
    private void Move()
    {
        anim.SetFloat("running", 1);
        if (timeVal <= 2)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (2 <= timeVal && timeVal <= 4)
        {
            anim.SetFloat("running", 0);
        }
        else if (timeVal > 4)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (timeVal >= 6) timeVal = 0;
    }

    //发现玩家
    private void FindPlayer()
    {
        timeVal += Time.deltaTime;
        Vector3 a = player.transform.position - transform.position;
        if (distance < 8)
        {
            anim.SetFloat("running", 1);
            transform.Translate(a * Time.fixedDeltaTime * 1, Space.World);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                collision.SendMessage("Die"); 
                break;
            case "Enemy":
                break;
            case "Box":
                Destroy(collision.gameObject);               
                break;
            case "Barrier":
                break;
            default:
                break;
        }
    }
    private void Attack()
    {
        if (timeVal >= AttackTime && lifeValue > 0)
        {
            timeVal = 0;
        }
    }

}