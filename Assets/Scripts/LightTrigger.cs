using DynamicLight2D;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public DynamicLight light2d;
    public bool isTriggered;

    private void Start()
    {
        light2d.OnEnterFieldOfView += OnEnter;
        light2d.OnExitFieldOfView += OnExit;
    }

    private void OnEnter(GameObject g, DynamicLight light)
    {
        if (g.GetInstanceID() != gameObject.GetInstanceID()) return;
        isTriggered = !isTriggered;
    }
    
    private void OnExit(GameObject g, DynamicLight light)
    {
        if (g.GetInstanceID() != gameObject.GetInstanceID()) return;
        isTriggered = !isTriggered;
    }
}
