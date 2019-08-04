using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isMoving;
    private Coroutine _coroutine;
    
    public IEnumerator Move(Vector3 target, float overTime)
    {
        isMoving = true;
        var startTime = Time.time;
        while(Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(transform.position, target,
                (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.position = target;
        isMoving = false;
    }
}