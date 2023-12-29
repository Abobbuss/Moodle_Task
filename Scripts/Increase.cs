using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase : MonoBehaviour
{
    [SerializeField] private float _speedIncrease;

    private void Update()
    {
        Vector3 currentScale = gameObject.transform.localScale;

        Vector3 newSize = currentScale + new Vector3(_speedIncrease, _speedIncrease, _speedIncrease) * Time.deltaTime;

        gameObject.transform.localScale = newSize;
    }
}

