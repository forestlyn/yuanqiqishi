using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead;
    public bool isDefeat;

    //引用
    public GameObject Born;
    public Text textPlayerScore;
    public Text textPlayerLifeValue;

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
        if (isDead)
        {
            Recover();
        }

    }

    private void Recover()
    {
        if (lifeValue <= 0)
        {

        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().isCreatePlayer = true;
            isDead = false;
        }
    }
}