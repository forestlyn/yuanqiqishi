using System.Collections;
using System.Collections.Generic;
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
        CreateWall(-7, 7, 7, false);
        CreateWall(-7, 7, -7, false);
        CreateWall(-7, 2, -7, true);
        CreateWall(-7, 2, 7, true);
        CreateWall(5, 7, -7, true);
        CreateWall(5, 7, 7, true);
        CreateWall(-15, -8, 5, false);
        CreateWall(-15, -8, 2, false);
        CreateWall(8, 15, 5, false);
        CreateWall(8, 15, 2, false);
        CreateWall(-6, 2, -15, true);
        CreateWall(-6, 2, -30, true);
        CreateWall(6, 10, -15, true);
        CreateWall(3, 10, -30, true);
        CreateWall(-29, -15, -6, false);
        CreateWall(-30, -20, 11, false);
        CreateWall(11, 22, -15, true);
        CreateWall(11, 22, -19, true);
        CreateWall(-15, -5, 23, false);
        CreateWall(-25, -19, 23, false);
        CreateWall(24, 34, -5, true);
        CreateWall(24, 37, -25, true);
        CreateWall(-25, 8, 38, false);
        CreateWall(-4, 8, 34, false);
        CreateWall(25, 34, 9, true);
        CreateWall(38, 45, 9, true);
        CreateWall(10, 23, 25, false);
        CreateWall(10, 35, 45, false);
        CreateWall(17, 25, 24, true);
        CreateWall(25, 45, 35, true);
        CreateWall(30, 34, 25, false);
        CreateWall(-7, 25, 29, true);
        CreateWall(6, 17, 15, true);
        CreateWall(16, 23, 17, false);
        CreateWall(-7, 1, 15, true);
        CreateWall(16, 28, -7, false);

        CreateItemGameObject(item[4], new Vector3(17, 30, 0), Quaternion.identity);
        CreateItemGameObject(item[5], new Vector3(17, 26, 0), Quaternion.identity);
        
                
        //实例化敌人
        CreateItemGameObject(item[1], new Vector3(26,6, 0), Quaternion.identity);
        CreateItemGameObject(item[2], new Vector3(26, 8, 0), Quaternion.identity);
        CreateItemGameObject(item[3], new Vector3(26, 10, 0), Quaternion.identity);

        

    }

    private void CreateWall(int i, int j, int n,bool up)
    {
        if (up)
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

