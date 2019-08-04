using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TorchControll : MonoBehaviour
{
    public GameObject light;
    private Light _light;
    private MeshRenderer _mesh;
    private bool _turnedOff;
    private float _battery = 10f;

    private void Start()
    {
        _light = light.GetComponent<Light>();
        _mesh = light.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (_light.GetLife() == 0 && !_turnedOff)
        {
            _mesh.enabled = false;
            _turnedOff = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Battery"))
        {
            transform.parent.GetComponentInChildren<Light>().AddLife(_battery);
            Destroy(collision.gameObject);
            _mesh.enabled = true;
        }
    }
}