using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public Text ScoreText;
    public GameObject prefabReady, prefabAction,prefabGame,prefabMenu;
    
    public int gameScore = 0;
    public int[] CountClick = new int[4];
    Vector2[] HoleLo = {
        new Vector2(-5f,-2.5f), new Vector2(0f, -2.5f),new Vector2(-2.5f,-2.5f),
        new Vector2(2.5f,-2.5f),new Vector2(5f,-2.5f),new Vector2(-5f,0f),
        new Vector2(-2.5f,0f), new Vector2(0f,0f),new Vector2(2.5f,0f),
        new Vector2(5f,0f)
    };

    void Start()
    {
        ScoreText.text = string.Format("SCORE : 0");
        Invoke("ShowReady", 0f);
        Invoke("ShowAction", 1f);
        Invoke("GameStart", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("SCORE : {0}",gameScore);
    }

    void ShowReady()
    {
        GameObject _obj = Instantiate(prefabReady, Vector2.zero, Quaternion.identity);
        Destroy(_obj, 1f);
    }
    void ShowAction()
    {
        GameObject _obj = Instantiate(prefabAction, Vector2.zero, Quaternion.identity);
        Destroy(_obj, 1f);
    }

    void GameStart()
    {
        ManagerApp.singleton.gamePlaying = true;
        for (int i = 0; i < 10; i ++)
            Instantiate(prefabGame, HoleLo[i], Quaternion.identity);
    }

    public void AddScore(int m)
    {
        if (!ManagerApp.singleton.gamePlaying) return;
        if (m == 0) gameScore += 100;
        else if (m == 1) gameScore += 300;
        else gameScore += 500;
        ScoreText.GetComponent<ScoreAnimation>().Scoring();
    }
    public void MinusScore()
    {
        if (!ManagerApp.singleton.gamePlaying) return;
        CountClick[3]++;
        gameScore -= 1000;
        if (gameScore < 0)
            gameScore = 0;
        ScoreText.GetComponent<ScoreAnimation>().Scoring();
    }
    public void ClickMolly(int m)
    {
        CountClick[m]++;
    }
    public void TimeOver()
    {
        if (ManagerApp.singleton.bestScore < gameScore)
        {
            ManagerApp.singleton.bestScore = gameScore;
            for(int i = 0; i < 4; i++)
            {
                ManagerApp.singleton.hole[i] = CountClick[i];
            }
            ManagerApp.singleton.SaveMolly();
        }
        ManagerApp.singleton.playCount++;
        Instantiate(prefabMenu, Vector2.zero, Quaternion.identity);
    }
}