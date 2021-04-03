using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //属性值
    public float timeVal;

    //引用
    public GameObject BulletPrefab;

    void Start()
    {

    }


    void Update()
    {
        timeVal += Time.deltaTime;
        GunAttack();
    }

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
            float m_fireAngle = Vector3.Angle(m_mousePosition, Vector3.right);

            if (m_mousePosition.y - transform.position.y < 0)
            {
                m_fireAngle = -m_fireAngle;
            }
            // 计时器归零
            timeVal = 0;

            // 生成子弹
            GameObject m_bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

            // 速度
            m_bullet.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition - transform.position).normalized * 10);

            // 角度
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
            transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
        }
        
    }
    


}
