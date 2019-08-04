using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform door;
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
            door.position = Vector3.Lerp(door.position, _end, _s);
        }
        else
        {
            _s = 0;
            _e += Time.deltaTime;
            door.position = Vector3.Lerp(door.position, _start, _e);
 
        }
    }

    private bool IsTriggered()
    {
        var rt = true;
        foreach (var lt in lts)
        {
            if (lt.isTriggered == false)
            {
                rt = false;
            }
        }
        return rt;
    }
}
