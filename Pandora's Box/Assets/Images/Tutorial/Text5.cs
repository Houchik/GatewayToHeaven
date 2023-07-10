using UnityEngine;

public class Text5 : MonoBehaviour
{
    [SerializeField] private GameObject _nextDialogue;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            _nextDialogue.SetActive(false);
        }
    }
}
