using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //属性值
    public float moveSpeed = 3;
   
    //引用
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        
         Move();
        Attack();
    }
    
    //攻击
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
        }
    }

    //移动
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Moveh(h);
        Movev(v);
    }
    private void Moveh(float h)
    {
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
    private void Movev(float v)
    {
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
    }

}
