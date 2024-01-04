using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.2f;

    private const string _playerTag = "Player";
    private bool _isPlayerInside = false;

    private void Update()
    {
        ChangeVolumeAudio(_isPlayerInside);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_playerTag))
            _isPlayerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_playerTag))
            _isPlayerInside = false;
    }

    private void ChangeVolumeAudio(bool isPlayerInside)
    {
        if (isPlayerInside)
            _audioSource.volume += _fadeSpeed * Time.deltaTime;
        else
            _audioSource.volume -= _fadeSpeed * Time.deltaTime;
    }
}
