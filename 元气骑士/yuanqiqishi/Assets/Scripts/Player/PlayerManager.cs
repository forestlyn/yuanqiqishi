using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //属性值
    public float Skill;
    public bool isDefeat;
    public float LifeValue;
    public float Shield;
    public float Bullet;

    //引用
    public Text textPlayerBullet;
    public Text textPlayerLifeValue;
    public Text textPlayerShieldValue;
    public GameObject HealthBar;
    public GameObject ShieldBar;
    public GameObject BulletBar;
    public GameObject SkillBar;

    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }

    internal delegate void MyDelegate(float num, float maxnum, string tag, GameObject name);
    MyDelegate myDelegate;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat)
        {
            SceneManager.LoadScene(0);
            return;
        }

        myDelegate = SetBar;
        myDelegate(LifeValue, Player.Instance.MaxPlayerLifeValue, "HealthBar", HealthBar);
        myDelegate(Shield, Player.Instance.MaxShield, "ShieldBar", ShieldBar);
        myDelegate(Bullet, Player.Instance.MaxBullet, "BulletBar", BulletBar);
        myDelegate(Skill, Player.Instance.MaxSkillTimeVal, "SkillBar", SkillBar);

        SetText();
    }

    //UI
    private void SetBar(float num,float maxnum, string tag,GameObject Bar)
    {
        Bar = GameObject.FindGameObjectWithTag(tag);
        Bar.GetComponent<Image>().fillAmount = num / maxnum;
    }

    private void SetText()
    {
        textPlayerBullet.text = Bullet + "/" + Player.Instance.MaxBullet;
        textPlayerLifeValue.text = LifeValue + "/" + Player.Instance.MaxPlayerLifeValue;
        textPlayerShieldValue.text = Shield + "/" + Player.Instance.MaxShield;
    }



}