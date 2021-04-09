using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public float TimeVal;
    //0.born 1.Enemy1Gun 2.Enemy2Magic 3.Enemy3Pig 4.Box 5.Barrier 6.Wall 
    public GameObject[] item;
    private List<Vector3> itemPosition = new List<Vector3>();

    public void Update()
    {
        TimeVal += Time.deltaTime;
        if (TimeVal >= 5)
        {
            if (!PlayerManager.Instance.isDefeat)
            {
                CreateEnemy();
                TimeVal = 0;
            }
        }
    }

    private void Awake()
    {
        //实例化墙
        FileStream file = new FileStream("CreateWall.txt", FileMode.Open, FileAccess.Read);
        StreamReader files = new StreamReader(file);

        for (int i = 0; i < 36; i++)
        {
            int a, b, c, d;
            string line;
            line = files.ReadLine();
            string[] lines = line.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            a = int.Parse(lines[0]);
            b = int.Parse(lines[1]);
            c = int.Parse(lines[2]);
            d = int.Parse(lines[3]);
            CreateWall(a, b, c, d);          
        }
        file.Close();

        CreateItemGameObject(item[4], new Vector3(17, 30, 0), Quaternion.identity);
        CreateItemGameObject(item[5], new Vector3(17, 26, 0), Quaternion.identity);
        
                
        //实例化敌人
        CreateItemGameObject(item[1], new Vector3(26,6, 0), Quaternion.identity);
        CreateItemGameObject(item[2], new Vector3(26, 8, 0), Quaternion.identity);
        CreateItemGameObject(item[3], new Vector3(26, 10, 0), Quaternion.identity);

        

    }

    private void CreateWall(int i, int j, int n,int up)
    {
        if (up == 1)
        {
            for (; i <= j; i++)
            {
                CreateItemGameObject(item[6], new Vector3(n, i, 0), Quaternion.identity);
            }
        }
        else
        {
            for (; i <= j; i++)
            {
                CreateItemGameObject(item[6], new Vector3(i, n, 0), Quaternion.identity);
            }
        }
        
    }
    private void CreateItemGameObject(GameObject createGameObject, Vector3 createPosition, Quaternion createRotation)
    {
        Instantiate(createGameObject, createPosition, createRotation, gameObject.transform);
        itemPosition.Add(createPosition);
    }

    //产生敌人
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        if (num == 0)
        {
            CreateItemGameObject(item[0], new Vector3(-1, 0, 0), Quaternion.identity);
        }
        else if (num == 1)
        {
            CreateItemGameObject(item[0], new Vector3(3, -3, 0), Quaternion.identity);
        }
        else if (num == 2)
        {
            CreateItemGameObject(item[0], new Vector3(3, -6, 0), Quaternion.identity);
        }
    }
}

