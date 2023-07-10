using UnityEngine;
using UnityEngine.SceneManagement;

public class Text67 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Start._wasTutorialCompleted = true;
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }
    }
}
