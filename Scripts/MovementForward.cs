using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 direction = new Vector3(_speed, 0f, 0f);

        transform.Translate(_speed * Time.deltaTime * direction);
    }
}
