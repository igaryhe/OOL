using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 2f;
    private void Update()
    {
        LookAtMousePosition();
        Move();
    }

    private void LookAtMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (Vector2) (mousePos - transform.position).normalized;
        transform.up = direction;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var deltaY = _speed * Time.deltaTime;
            transform.position += new Vector3(0, deltaY);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var deltaY = _speed * Time.deltaTime;
            transform.position += new Vector3(0, -deltaY);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var deltaX = _speed * Time.deltaTime;
            transform.position += new Vector3(-deltaX, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var deltaX = _speed * Time.deltaTime;
            transform.position += new Vector3(deltaX, 0);
        }
    }
}
