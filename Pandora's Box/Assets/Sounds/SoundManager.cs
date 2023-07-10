using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _camera;
    [SerializeField] private AudioSource _camera2;

    public void PlaySound(AudioClip _clip)
    {
        _camera.clip = _clip;
        _camera2.Stop();
        _camera.Play();
    }

    public void PlaySound2(AudioClip _clip)
    {
        _camera.clip = _clip;
        _camera.Play();
    }
}
