using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{

   
    public Text textButton;
    // Use this for initialization
    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TaskOnClick();
        }
    }
    public void TaskOnClick()
    {
        textButton.text = "加载中";
        SceneManager.LoadScene("yuanqiqishi");
    }
}
