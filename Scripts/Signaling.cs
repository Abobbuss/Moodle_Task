using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.2f;
    [SerializeField] private House _house;

    private Coroutine _currentCoroutine;

    private IEnumerator ChangeVolumeOverTime(bool isPlayerInside)
    {
        float maxValue = 1.0f;
        float minValue = 0.0f;
        float targetVolume = isPlayerInside ? maxValue : minValue;

        while (!Mathf.Approximately(_audioSource.volume, targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0.0f)
            StopAudio();

        _currentCoroutine = null;
    }

    private void OnEnable()
    {
        _house.PlayerInsideChanged += HandlePlayerInsideChanged;
    }

    private void OnDisable()
    {
        _house.PlayerInsideChanged -= HandlePlayerInsideChanged;
    }

    private void HandlePlayerInsideChanged(bool isPlayerInside)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        if (isPlayerInside)
            StartAudio();

        _currentCoroutine = StartCoroutine(ChangeVolumeOverTime(isPlayerInside));
    }

    public void StartAudio()
    {
        _audioSource.Play();
    }

    private void StopAudio()
    {
        _audioSource.Stop();
    }
}