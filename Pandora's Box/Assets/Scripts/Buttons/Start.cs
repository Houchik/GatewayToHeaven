using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public static bool _wasTutorialCompleted = false;

    public void Clicked()
    {
        if (_wasTutorialCompleted == false)
        {
            SceneManager.LoadScene(1);
        }

        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }
    }
}
