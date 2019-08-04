using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject door;
    private bool _isTriggered;
    private Door _door;
    private Vector3 _end;

    private void Awake()
    {
        _door = door.GetComponent<Door>();
        _end = door.transform.position + new Vector3(3, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isTriggered) return;
        StartCoroutine(_door.Move(_end, 1));
        _isTriggered = !_isTriggered;
    }
}