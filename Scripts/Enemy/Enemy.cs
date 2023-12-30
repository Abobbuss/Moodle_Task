using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _transformToRotate;

    private void Update()
    {
        Vector3 direction = new Vector3(_speed, 0f, 0f);
        transform.Translate(_speed * Time.deltaTime * direction);
    }
}