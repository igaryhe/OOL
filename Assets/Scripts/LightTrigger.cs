using DynamicLight2D;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject door;
    public DynamicLight light2d;
    private Vector3 _start, _end;
    private Coroutine _coroutine;
    private Door _door;

    private void Start()
    {
        _start = door.transform.position;
        _end = _start + new Vector3(4, 0, 0);
        _door = door.GetComponent<Door>();
        light2d.OnEnterFieldOfView += OnEnter;
        light2d.OnExitFieldOfView += OnExit;
    }

    private void OnEnter(GameObject g, DynamicLight light)
    {
        if (!g.CompareTag("Button")) return;
        if (_door.isMoving)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(_door.Move(_end, 1));
    }
    
    private void OnExit(GameObject g, DynamicLight light)
    {
        if (!g.CompareTag("Button")) return;
        if(_door.isMoving)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(_door.Move(_start, 1));
    }
}
