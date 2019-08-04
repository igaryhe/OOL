using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    public LightTrigger[] lts;
    public Vector3 offset;
    private Coroutine _coroutine;
    private Vector3 _start, _end;
    private float _s, _e;

    private void Start()
    {
        _start = door.transform.position;
        _end = _start + offset;
    }

    private void Update()
    {
        if (IsTriggered())
        {
            _e = 0;
            _s += Time.deltaTime;
            door.transform.position = Vector3.Lerp(door.transform.position, _end, _s);
            /*
            if (door.isMoving)
            {
                // StopCoroutine(_coroutine);
                door.transform.position = Vector3.Lerp(door.transform.position, _end, Time.time);
                if (door.transform.position == _end)
                {
                    door.isMoving = false;
                }
            }
            */
            // _coroutine = StartCoroutine(door.Move(_end, 1));
        }
        else
        {
            _s = 0;
            _e += Time.deltaTime;
            door.transform.position = Vector3.Lerp(door.transform.position, _start, _e);
            /*
            if (door.isMoving)
            {
                // StopCoroutine(_coroutine);
                door.transform.position = Vector3.Lerp(door.transform.position, _start, Time.time);
                if (door.transform.position == _start)
                {
                    door.isMoving = false;
                }
            }
            */
            // _coroutine = StartCoroutine(door.Move(_start, 1));
        }
    }

    private bool IsTriggered()
    {
        var rt = true;
        foreach (var lt in lts)
        {
            if (lt.isTriggered == false)
            {
                Debug.Log("false");
                rt = false;
            }
        }
        return rt;
    }
}
