using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float timer = 30f;
    void Start()
    {
        timerText.text = string.Format("30.00");
    }
    void Update()
    {
        if (ManagerApp.singleton.gamePlaying)
        {
            timer -= Time.deltaTime;
            timerText.text = string.Format("{0:N2}", timer);
        }
        if(timer <= 0 && ManagerApp.singleton.gamePlaying)
        {
            ManagerApp.singleton.gamePlaying = false;
            GameObject.Find("GameManager").SendMessage("TimeOver");
        }
    }
}
