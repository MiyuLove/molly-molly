using UnityEngine;

public class ManagerApp : MonoBehaviour
{
    public static ManagerApp singleton;

    [HideInInspector] public int bestScore = 0;
    [HideInInspector] public int playCount = 0;
    [HideInInspector] public int[] hole = new int[4];
    [HideInInspector] public bool gamePlaying = false;

    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }

        Load();
    }

    void Load()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        for (int i = 0; i < 4; i++)
        {
            hole[i] = PlayerPrefs.GetInt("Hole" + i, 0);
        }
    }
    public void SaveMolly()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        for (int i = 0; i < 4; i++)
            PlayerPrefs.SetInt("Hole" + i, hole[i]);
    }
}