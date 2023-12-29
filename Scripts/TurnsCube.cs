using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsCube : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";

    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 direction = new Vector3(0f, Input.GetAxis(Horizontal), 0f);

        gameObject.transform.Rotate(_speed * direction * Time.deltaTime);
    }
}
