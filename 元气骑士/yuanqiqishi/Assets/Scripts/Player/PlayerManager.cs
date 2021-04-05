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
        SetText();
        SetBar();
    }

    //UI
    private void SetBar()
    {
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar");
        HealthBar.GetComponent<Image>().fillAmount = LifeValue / 6;
        ShieldBar = GameObject.FindGameObjectWithTag("ShieldBar");
        ShieldBar.GetComponent<Image>().fillAmount = Shield / 3;
        BulletBar = GameObject.FindGameObjectWithTag("BulletBar");
        BulletBar.GetComponent<Image>().fillAmount = Bullet / 180;
        SkillBar = GameObject.FindGameObjectWithTag("SkillBar");
        SkillBar.GetComponent<Image>().fillAmount = Skill / 20;
    }

    private void SetText()
    {
        textPlayerBullet.text = Bullet.ToString() + "/180";
        textPlayerLifeValue.text = LifeValue.ToString() + "/6";
        textPlayerShieldValue.text = Shield.ToString() + "/3";
    }

}