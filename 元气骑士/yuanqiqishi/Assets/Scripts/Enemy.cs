using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性值
    public float moveSpeed;
    public float timeVal;
    int num;
    public float lifeValue;


    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeVal += Time.fixedDeltaTime;
        Move(num);
    }
    public void Die()
    {
        lifeValue -= 3;
        if (lifeValue <= 0)
            Destroy(gameObject);
    }
    private void Move(int num)
    {
        if (num == 1)
        {
            if (timeVal <= 3)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime, Space.World);
            }
            else if (timeVal > 3)
                transform.Translate(Vector3.down * moveSpeed * Time.fixedDeltaTime, Space.World);
            if (timeVal >= 6) timeVal = 0;
        }
        else if (num == 2)
        {
            if (timeVal <= 3)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.fixedDeltaTime, Space.World);
            }
            else if (timeVal > 3) 
                transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime, Space.World);
            if (timeVal >= 6) timeVal = 0;
        }
    }
    
}
