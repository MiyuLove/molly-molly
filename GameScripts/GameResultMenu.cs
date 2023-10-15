using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultMenu : MonoBehaviour
{
    public Text Score, BestScore;
    public Text[] Hole = new Text[4];
    
    void Start()
    {
        GameObject _obj = GameObject.Find("GameManager");
        Score.text = string.Format("Score : {0}", 
            _obj.GetComponent<ManagerGame>().gameScore);
        BestScore.text = string.Format("BestScore : {0}", ManagerApp.singleton.bestScore);
        for(int i = 0; i < 4; i++)
        {
            Hole[i].text = string.Format("{0}", _obj.GetComponent<ManagerGame>().CountClick[i]);
        }
    }
}
