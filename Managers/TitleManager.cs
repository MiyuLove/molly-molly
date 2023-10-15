using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleManager : MonoBehaviour
{
    public Text Score, Count;
    public Text[] Hole = new Text[4];
    void Start()
    {
        Score.text = string.Format("BEST SCORE : {0}", ManagerApp.singleton.bestScore);
        Count.text = string.Format("Play Count : {0}", ManagerApp.singleton.gamePlaying);
        Hole[0].text = string.Format("{0}", ManagerApp.singleton.hole[0]);
        Hole[1].text = string.Format("{0}", ManagerApp.singleton.hole[1]);
        Hole[2].text = string.Format("{0}", ManagerApp.singleton.hole[2]);
        Hole[3].text = string.Format("{0}", ManagerApp.singleton.hole[3]);
    }
}
