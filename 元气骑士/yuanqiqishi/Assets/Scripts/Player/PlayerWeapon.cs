using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //属性值
    public float timeVal;
    public Vector3 m_mousePosition;
    public float m_fireAngle;
    private float SkillTimeVal = 20f;
    private float SkilltimeContinue;
    public bool isskill;


    //引用
    public GameObject BulletPrefab;
    private Transform player;
    void Start()
    {

    }


    void Update()
    {
        if (!PlayerManager.Instance.isDefeat)
        {
            
            
            if (Input.GetMouseButtonDown(1) && SkillTimeVal >= 20f)
            {
                isskill = true;
                Player.Instance.IsSkilling = true;
            }
            if (isskill)
            {
                SkilltimeContinue += Time.deltaTime;
            }
            player = GameObject.FindGameObjectWithTag("Player").transform;
            timeVal += Time.deltaTime;
            SkillTimeVal += Time.deltaTime;
            if (!isskill && PlayerManager.Instance.Bullet >= 3) GunAttack();
            Skill();
            PlayerManager.Instance.Skill = SkillTimeVal > 20 ? 20 : SkillTimeVal;
        }
    }

    //攻击
    private void GunAttack()
    {
        if (Input.GetMouseButtonDown(0) && timeVal > 0.1f )
        {
            // 获取鼠标坐标并转换成世界坐标
            m_mousePosition = Input.mousePosition;
            m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);

            m_mousePosition.z = 0;
            // 子弹角度与初始方向的角度
            m_fireAngle = Vector3.Angle(m_mousePosition-player.position, Vector3.right);

            //如果在下方，角度取反
            if (m_mousePosition.y - player.position.y < 0)
            {
                m_fireAngle = -m_fireAngle;
            }

            // 计时器归零
            timeVal = 0;
            
            // 生成子弹
            PlayerManager.Instance.Bullet -= 10;
            GameObject m_bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

            // 速度
            m_bullet.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition - player.position).normalized * 10);

            // 角度
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
            transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
        }       
    }

    //技能
    public void Skill()
    {
        if (SkillTimeVal >= 20f && isskill)
        {
            SkillGunAttack();
            if (SkilltimeContinue >= 5f)
            {
                SkillTimeVal = 0;
                SkilltimeContinue = 0;
                isskill = false;
            }           
        }       
    }
    public void SkillGunAttack()
    {
        if (timeVal > 0.2f)
        {
            // 获取鼠标坐标并转换成世界坐标
            m_mousePosition = Input.mousePosition;
            m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);

            m_mousePosition.z = 0;
            // 子弹角度与初始方向的角度
            m_fireAngle = Vector3.Angle(m_mousePosition - player.position, Vector3.right);

            //如果在下方，角度取反
            if (m_mousePosition.y - player.position.y < 0)
            {
                m_fireAngle = -m_fireAngle;
            }

            // 计时器归零
            timeVal = 0;
            
            // 生成子弹
            GameObject m_bullet1 = Instantiate(BulletPrefab, transform.position + new Vector3(0.1f, 0.1f, 0), Quaternion.identity) as GameObject;
            GameObject m_bullet2 = Instantiate(BulletPrefab, transform.position + new Vector3(-0.1f, -0.1f, 0), Quaternion.identity) as GameObject;
            // 速度
            m_bullet1.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition - player.position).normalized * 10);
            m_bullet2.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition - player.position).normalized * 10);
            // 角度
            m_bullet1.transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
            m_bullet2.transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
            transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
        }
    }

    
}
