using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //属性值
    public float PlayerLifeValue;
    public float MaxPlayerLifeValue;
    public float Shield;
    public float MaxShield;
    public float Bullet;
    public float MaxBullet;
    private float moveSpeed = 5;   
    public float playerATK;
    public float SkillTimeVal = 20;
    public float MaxSkillTimeVal;
    public bool IsSkilling;
    public float RecoverTime;
   
    //引用
    public GameObject BulletPrefab;
    public GameObject SkillPrefab;
    public Animator anim;

    private static Player instance;

    public static Player Instance { get => instance; private set => instance = value; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (!PlayerManager.Instance.isDefeat)
        {           
            RecoverTime += Time.deltaTime;
            SkillTimeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.Instance.isDefeat)
        {
            RecoverShield();
            RecoverTime += Time.fixedDeltaTime;
            SkillTimeVal += Time.fixedDeltaTime;
            Skill();
            Move();
        }
    }
    
    
    private void Die()
    {
        RecoverTime = 0;
        if (Shield > 0)
        {
            Shield--;
            PlayerManager.Instance.Shield = Shield;
        }
        else
        {
            PlayerLifeValue--;
            PlayerManager.Instance.LifeValue = PlayerLifeValue;
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
        anim.SetFloat("running", Mathf.Abs(h) + Mathf.Abs(v));
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

    //技能
    public void Skill()
    {
        if (IsSkilling)
        {
            Instantiate(SkillPrefab, transform.position, transform.rotation);
            IsSkilling = false;
        }
    }

    //脱战回盾
    public void RecoverShield()
    {
        if (RecoverTime > 10 && Shield < 3)
        {
            Shield++;
            PlayerManager.Instance.Shield = Shield;
            RecoverTime = 0;
        }
    }
}
