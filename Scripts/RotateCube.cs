using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        Vector3 direction = new Vector3(0f, _speedRotate,  0f);

        gameObject.transform.Rotate(direction * Time.deltaTime);
    }
}
