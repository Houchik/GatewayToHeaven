using UnityEngine;

public class Return : MonoBehaviour
{
    public void Clicked()
    {
        GameObject.Find("PauseMenu").SetActive(false);
        Time.timeScale = 1;
    }
}
