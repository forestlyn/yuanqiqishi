using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //属性值
    public float lifeValue;
    public float Shield;
    public int playerScore = 0;
    public bool isDefeat;

    //引用
    public GameObject Born;
    public Text textPlayerScore;
    public Text textPlayerLifeValue;
    public Text textPlayerShieldValue;

    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
}