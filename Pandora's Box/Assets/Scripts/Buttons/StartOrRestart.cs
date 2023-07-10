using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOrRestart : MonoBehaviour
{
    public void Clicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
