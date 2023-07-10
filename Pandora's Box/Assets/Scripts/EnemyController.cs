using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _speedMin = 1;
    [SerializeField] private int _speedMax = 5;
    [SerializeField] private AudioClip _clipHit;
    [SerializeField] private AudioClip _clipDeath;
    [SerializeField] private AudioClip _clipPortal;

    private SoundManager _soundManager;

    private int _speed;
    private GameObject _dialogue;
    private GameObject _trigger;
    private GameObject _player;

    private int _killClickAmount;
    private int _clickAmount = 0;

    private bool _isAllocated = false;

    private void Start()
    {
        _soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();
        _speed = Random.Range(_speedMin, _speedMax + 1);
        _killClickAmount = Random.Range(1, 3);
        _player = GameObject.Find("Running");
        _trigger = GameObject.Find("Trigger");
        _dialogue = gameObject.transform.Find("Emoji").gameObject;
        gameObject.transform.LookAt(_trigger.transform.position);
    }

    private void Update()
    {
        if (_isAllocated)
        {
            if (Input.GetMouseButtonDown(0) && _player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hit") == false)
            {
                _soundManager.PlaySound2(_clipHit);
                _player.GetComponent<Animator>().Play("Hit");
                _clickAmount++;
                if(_clickAmount == _killClickAmount)
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
        _soundManager.PlaySound2(_clipPortal);
        if (gameObject.CompareTag("Good"))
        {
            _player.GetComponent<PlayerController>().ChangeArrow(1f, 25);
        }
        else if (gameObject.CompareTag("Bad"))
        {
            _player.GetComponent<PlayerController>().ChangeArrow(-1f, -65);
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
        _soundManager.PlaySound2(_clipDeath);
        if (gameObject.CompareTag("Good"))
        {
            _player.GetComponent<PlayerController>().ChangeArrow(-1f, -65);
        }
        else if (gameObject.CompareTag("Bad"))
        {
            _player.GetComponent<PlayerController>().ChangeArrow(1f, 25);
        }
        Destroy(gameObject);
    }
}
