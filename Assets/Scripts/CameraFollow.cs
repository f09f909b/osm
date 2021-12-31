using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [Range(1,10)] private float _smoothFactor;
    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetCachedPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetCachedPosition, _smoothFactor * Time.fixedDeltaTime);
        transform.position = targetCachedPosition;
    }
}
