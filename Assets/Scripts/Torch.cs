using System;
using System.Collections;
using System.Collections.Generic;
using DynamicLight2D;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torch;
    private DynamicLight _dl;
    private bool _isAttached = true;
    private float _l2, _r2;
    private float _radiusSpeed = 5f;
    private float _angleSpeed = 50f;
    private Vector3 _offset;

    private void Start()
    {
        _dl = torch.GetComponent<DynamicLight>();
        _offset = new Vector3(0.26f, 0, 0);
    }

    private void Update()
    {
        Follow();
        Zoom();
        Place();
    }

    private void Follow()
    {
        if (!_isAttached) return;
        var pos = transform.position + transform.TransformDirection(_offset);
        torch.transform.position = pos;
        torch.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
    }
    private void Zoom()
    {
        _l2 = Input.GetAxis("L2");
        _r2 = Input.GetAxis("R2");
        if (_l2 > 0.5 && _dl.RangeAngle > 2f)
        {
            
            _dl.LightRadius += _radiusSpeed * Time.deltaTime;
            _dl.RangeAngle -= _angleSpeed * Time.deltaTime;
        }

        if (_r2 > 0.5 && _dl.RangeAngle < 90)
        {
            _dl.LightRadius -= _radiusSpeed * Time.deltaTime;
            _dl.RangeAngle += _angleSpeed * Time.deltaTime;
        }
    }

    private void Place()
    {
        if (Input.GetButtonDown("Place"))
        {
            if (_isAttached)
            {
                _isAttached = !_isAttached;
            }
            else
            {
                if (Vector3.Distance(transform.position, torch.transform.position) < 0.5f)
                {
                    _isAttached = !_isAttached;
                }
            }
        }
    }
}
