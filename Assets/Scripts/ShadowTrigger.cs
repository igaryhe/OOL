using DynamicLight2D;
using UnityEngine;

public class ShadowTrigger : MonoBehaviour
{
    public DynamicLight light2d;
    [HideInInspector] public bool isTriggered;

    private void Start()
    {
        light2d.OnEnterFieldOfView += OnEnter;
        light2d.OnExitFieldOfView += OnExit;
    }

    private void OnEnter(GameObject g, DynamicLight light)
    {
        if (!g.CompareTag("Button")) return;
        isTriggered = false;
    }
    
    private void OnExit(GameObject g, DynamicLight light)
    {
        if (!g.CompareTag("Button")) return;
        isTriggered = true;
    }
}