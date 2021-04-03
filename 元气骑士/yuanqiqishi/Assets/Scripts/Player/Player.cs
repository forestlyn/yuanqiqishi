using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //属性值
    public float PlayerLifeValue = 10;
    public float Shield = 6;
    public float moveSpeed = 5;
    
    public float playerATK;
   
    //引用
    public GameObject BulletPrefab;
    public Animator anim;

    private static Player instance;

    public static Player Instance { get => instance; set => instance = value; }

    void Start()
    {
        
    }

  
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Move();     
    }
    
    //攻击
    

    public void Die()
    {
        if (Shield > 0)
        {
            Shield--;
            PlayerManager.Instance.Shield = Shield;
        }
        else
        {
            PlayerLifeValue--;
            PlayerManager.Instance.lifeValue = PlayerLifeValue;
        }
        if (PlayerLifeValue <= 0)
        {
            anim.SetBool("isDead", true);
            PlayerManager.Instance.isDefeat = true;
        }
            
    }

    //移动
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        anim.SetFloat("running", Mathf.Abs(h + v));
        Moveh(h);
        Movev(v);
    }
    private void Moveh(float h)
    {
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if (h > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void Movev(float v)
    {
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
}
