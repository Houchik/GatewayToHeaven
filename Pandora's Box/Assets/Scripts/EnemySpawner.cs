using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _createEnemyTime;
    private float _timer;

    [SerializeField] private int _mapBondaryX;
    [SerializeField] private int _mapBondaryXNegative;
    [SerializeField] private int _mapBondaryZ;
    [SerializeField] private int _mapBondaryZNegative;

    [SerializeField] private int _createEnemyDistance;

    private int _xPosition;
    private int _zPosition;

    private Vector3 _enemyPosition;

    private int _typeIndex;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _createEnemyTime)
        {
            _xPosition = Random.Range(_mapBondaryXNegative, _mapBondaryX + 1);
            _zPosition = Random.Range(_mapBondaryZNegative, _mapBondaryZ + 1);
            _typeIndex = Random.Range(1, 101);
            if (_typeIndex >= 1 && _typeIndex < 12)
            {
                _typeIndex = 0;
            }

            else if (_typeIndex >= 12 && _typeIndex < 23)
            {
                _typeIndex = 1;
            }

            else if (_typeIndex >= 23 && _typeIndex < 34)
            {
                _typeIndex = 2;
            }

            else if (_typeIndex >= 34 && _typeIndex < 45)
            {
                _typeIndex = 3;
            }

            else if (_typeIndex >= 45 && _typeIndex < 59)
            {
                _typeIndex = 4;
            }

            else if (_typeIndex >= 59 && _typeIndex < 73)
            {
                _typeIndex = 5;
            }

            else if (_typeIndex >= 73 && _typeIndex < 87)
            {
                _typeIndex = 6;
            }

            else if (_typeIndex >= 87 && _typeIndex < 101)
            {
                _typeIndex = 7;
            }

            _enemyPosition = new Vector3(_xPosition, 0.5f, _zPosition);
            if (Vector3.Distance(_enemyPosition, _player.transform.position) >= _createEnemyDistance)
            {
                Instantiate(_enemy[_typeIndex], _enemyPosition, Quaternion.identity);
                _timer = 0;
            }
        }
    }
}
