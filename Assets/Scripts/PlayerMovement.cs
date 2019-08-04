using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5f;
    private Rigidbody2D _rb;
    private float _x, _y, _rx, _ry;
    private float _rotateSpeed = 100f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        _rx = Input.GetAxis("RH");
        _ry = Input.GetAxis("RV");
        var direction = new Vector2(_rx, -_ry);
        var deltaAngle = Vector3.SignedAngle(transform.right, direction, Vector3.forward);
        if (deltaAngle > 5)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * _rotateSpeed);
        }
        else if (deltaAngle < -5)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * -_rotateSpeed);
        }
    }

    private void Move()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        _rb.MovePosition(_rb.position + _speed * Time.deltaTime * new Vector2(_x, _y));
    }
}
