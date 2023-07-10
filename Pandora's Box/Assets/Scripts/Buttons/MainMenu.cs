using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Clicked()
    {
        SceneManager.LoadScene(0);
    }
}
