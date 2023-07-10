using System.Collections;
using UnityEngine;

public class EditedEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _nextDialogue3;
    [SerializeField] private GameObject _nextDialogue2;
    [SerializeField] private GameObject _nextDialogue4;

    private float _speed = 0.5f;
    private GameObject _dialogue;
    private GameObject _trigger;
    private GameObject _player;

    private int _killClickAmount;
    private int _clickAmount = 0;

    private bool _isAllocated = false;

    private bool _yahuikaknasvat = true;

    private void Start()
    {
        _killClickAmount = 1;
        _player = GameObject.Find("Running");
        _trigger = GameObject.Find("Trigger");
        _dialogue = gameObject.transform.Find("Emoji").gameObject;
        gameObject.transform.LookAt(_trigger.transform.position);
    }

    private void Update()
    {
        if (_isAllocated)
        {
            if (_yahuikaknasvat)
            {
                _nextDialogue2.SetActive(true);
                Time.timeScale = 0;
                _yahuikaknasvat = false;
            }
            if (Input.GetMouseButtonDown(0) && _player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hit") == false)
            {
                _player.GetComponent<Animator>().Play("Hit");
                _clickAmount++;
                if (_clickAmount == _killClickAmount)
                {
                    StartCoroutine(EnemyKill());
                }
            }

            _dialogue.SetActive(true);
        }

        else
        {
            _dialogue.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _trigger.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _nextDialogue4.SetActive(true);
        Time.timeScale = 0;
        if (gameObject.CompareTag("Good"))
        {
            _player.GetComponent<PlayerController>().ChangeArrow(1f, 25);
        }
        else if (gameObject.CompareTag("Bad"))
        {
            _player.GetComponent<PlayerController>().ChangeArrow(-1f, -50);
        }
        Destroy(gameObject);
    }

    public void Aloccated(bool alocateCondition)
    {
        _isAllocated = alocateCondition;
    }

    private IEnumerator EnemyKill()
    {
        yield return new WaitForSeconds(1.1f);
        _player.SetActive(false);
        _nextDialogue3.SetActive(true);
        Time.timeScale = 0;
        if (gameObject.CompareTag("Good"))
        {
            _player.GetComponent<EditedPlayerController>().ChangeArrow(-1f, -50);
        }
        else if (gameObject.CompareTag("Bad"))
        {
            _player.GetComponent<EditedPlayerController>().ChangeArrow(1f, 25);
        }
        Destroy(gameObject);
    }
}
