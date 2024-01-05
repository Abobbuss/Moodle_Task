using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.2f;

    private const string _playerTag = "Player";
    private bool _isPlayerInside = false;
    private bool _isAudioPlaying = false;

    private void Update()
    {
        if (_isAudioPlaying)
            StartCoroutine(ChangeVolumeOverTime(_isPlayerInside));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _isPlayerInside = true;
            StartAudio();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_playerTag))
            _isPlayerInside = false;
    }

    private IEnumerator ChangeVolumeOverTime(bool isPlayerInside)
    {
        float targetVolume = isPlayerInside ? 1.0f : 0.0f;

        while (!Mathf.Approximately(_audioSource.volume, targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0.0f)
        {
            StopAudio();
        }
    }

    private void StartAudio()
    {
        if (_isAudioPlaying == false)
        {
            _isAudioPlaying = true;
            _audioSource.Play();
        }
    }

    private void StopAudio()
    {
        if (_isAudioPlaying)
        {
            _isAudioPlaying = false;
            _audioSource.Stop();
        }
    }
}