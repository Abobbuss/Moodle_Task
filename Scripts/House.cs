using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public event Action<bool> PlayerInsideChanged;
    private const string _playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
            PlayerInsideChanged?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_playerTag))
            PlayerInsideChanged?.Invoke(false);
    }
}
