using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _nextDialogue;

    private void Update()
    {
        Time.timeScale = 0;
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            _nextDialogue.SetActive(true);
        }
    }
}
