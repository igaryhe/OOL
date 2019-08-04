using DynamicLight2D;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    // public GameObject door;
    public DynamicLight light2d;
    // private Vector3 _start, _end;
    // public Vector3 offset;
    // private Coroutine _coroutine;
    // private Door _door;
    [HideInInspector] public bool isTriggered;

    private void Start()
    {
        // _start = door.transform.position;
        // _end = _start + offset;
        // _door = door.GetComponent<Door>();
        light2d.OnEnterFieldOfView += OnEnter;
        light2d.OnExitFieldOfView += OnExit;
    }

    private void OnEnter(GameObject g, DynamicLight light)
    {
        if (!g.CompareTag("Button")) return;
        isTriggered = true;
        /*
        if (_door.isMoving)
        {
            // StopCoroutine(_coroutine);
        }
        */
        // _coroutine = StartCoroutine(_door.Move(_end, 1));
    }
    
    private void OnExit(GameObject g, DynamicLight light)
    {
        if (!g.CompareTag("Button")) return;
        isTriggered = false;
        /*
        if(_door.isMoving)
        {
            // StopCoroutine(_coroutine);
        }
        */
        // _coroutine = StartCoroutine(_door.Move(_start, 1));
    }
}
