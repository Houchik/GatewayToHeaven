using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditedPlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _clipLose;
    [SerializeField] private AudioClip _clipWin;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _lossScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _pauseScreen;

    private Rigidbody _rb;
    private Vector3 _moveInput;

    private RaycastHit _hit;
    private GameObject _gameobjectHit;

    private bool _raycastExit = false;

    private Animator _anim;

    private GameObject _arrow;

    private int _arrowChange = 0;
    private float _arrowChanger = 0;
    private float _step;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _arrow = GameObject.Find("Arrow");
    }

    private void FixedUpdate()
    {
        _moveInput.x = -Input.GetAxis("Horizontal");
        _moveInput.z = -Input.GetAxis("Vertical");
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Hit") == false)
        {
            if (_moveInput.normalized != Vector3.zero)
            {
                if (!_particles.isPlaying)
                {
                    _particles.Play();
                }
                _anim.Play("Run");
                var forwardsAmount = Vector3.Dot(transform.forward, _moveInput);
                if (forwardsAmount >= 0)
                {
                    forwardsAmount = (1 - forwardsAmount) * 0.5f + forwardsAmount * 1;
                    forwardsAmount += 0.5f;
                }
                else if (forwardsAmount < 0)
                {
                    forwardsAmount = -forwardsAmount;
                    forwardsAmount = (1 - forwardsAmount) * 1 + forwardsAmount * 0.5f;

                }
                _speed = 3 * forwardsAmount;
            }
            else
            {
                if (_particles.isPlaying)
                {
                    _particles.Stop();
                }
                _anim.Play("Idle");
            }
        }

        _rb.MovePosition(_rb.position + _moveInput * _speed * Time.fixedDeltaTime);

        if (_arrowChanger != _arrowChange)
        {
            if (_arrowChange > _arrowChanger)
            {
                _step = 1;
            }
            else if (_arrowChange < _arrowChanger)
            {
                _step = -1;
            }
            _arrowChanger += _step;
            _arrow.transform.position = new Vector3(_arrow.transform.position.x, _arrow.transform.position.y + _step, _arrow.transform.position.z);
            if (_arrowChanger <= -350)
            {
                _lossScreen.SetActive(true);
                _soundManager.PlaySound(_clipLose);
                Time.timeScale = 0;
            }

            else if (_arrowChanger >= 350)
            {
                _winScreen.SetActive(true);
                _soundManager.PlaySound(_clipWin);
                Time.timeScale = 0;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (Physics.Raycast(new Vector3(transform.position.x, 1, transform.position.z), transform.forward, out _hit, 1.5f, LayerMask.GetMask("Enemy")))
        {
            _hit.collider.GetComponent<EditedEnemyController>().Aloccated(true);
            _raycastExit = true;
            _gameobjectHit = _hit.collider.gameObject;
        }

        else if (_raycastExit && _gameobjectHit != null)
        {
            _raycastExit = false;
            _gameobjectHit.GetComponent<EditedEnemyController>().Aloccated(false);
        }
    }

    public void ChangeArrow(float step, int arrowChange)
    {
        _arrowChange += arrowChange;
        if (_arrowChange >= 350)
        {
            _arrowChange = 350;
        }

        else if (_arrowChange <= -350)
        {
            _arrowChange = -350;
        }
        _step = step;
    }
}
