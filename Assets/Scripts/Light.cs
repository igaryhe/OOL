using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    float life = 10;

    private void lifeRemaining()
    {
        if (life > 0)
        {
            life -= 1 * Time.deltaTime;
        }
        else
        {
            life = 0;
        }
    }

    public float GetLife()
    {
        return life;
    }

    public void AddLife(float amount)
    {
        life += amount;
    }
    
    // Update is called once per frame
    void Update()
    {
        lifeRemaining();
    }
}