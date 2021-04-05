using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    //引用
    public GameObject PlayerPrefab;
    public GameObject[] EnemyPrefabList;

    public bool isCreatePlayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Borns", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Borns()
    {
        if (isCreatePlayer)
        {
            Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 3);
            Instantiate(EnemyPrefabList[num], transform.position, Quaternion.identity);     
        }
    } 
}
