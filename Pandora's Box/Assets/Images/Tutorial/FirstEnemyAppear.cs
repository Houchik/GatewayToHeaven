using UnityEngine;

public class FirstEnemyAppear : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _current1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _enemy.SetActive(true);
            _player.SetActive(true);
            Time.timeScale = 1;
            _current1.SetActive(false);
        }
    }
}
