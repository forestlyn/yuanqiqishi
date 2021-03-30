using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //属性值
    public float PlayerLifeValue = 10;
    public float Shield = 6;
    public float moveSpeed = 3;
    public float timeVal;
   
    //引用
    public GameObject BulletPrefab;
    public Animator anim;

    private static Player instance;

    public static Player Instance { get => instance; set => instance = value; }

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
        timeVal += Time.fixedDeltaTime;
        Move();
        GunAttack();
        
        
        
    }
    
    //攻击
    private void GunAttack()
    {
        if (Input.GetMouseButton(0) && timeVal > 0.2f)
        {
            // 获取鼠标坐标并转换成世界坐标
            Vector3 m_mousePosition = Input.mousePosition;
            m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
            // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
            m_mousePosition.z = 0;

            // 子弹角度
            float m_fireAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);

            // 计时器归零
            timeVal = 0;

            // 生成子弹
            GameObject m_bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

            // 速度
            m_bullet.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition - transform.position).normalized * 10);

            // 角度
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle + 90);
        }
    }

    public void Die()
    {
        PlayerLifeValue--;
        if (PlayerLifeValue <= 0)
            anim.SetBool("isDead", true);
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
