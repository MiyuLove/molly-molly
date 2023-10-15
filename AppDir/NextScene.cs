using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public void SceneNextString(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void SceneNextInt(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}
