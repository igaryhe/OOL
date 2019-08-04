using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    Text lifeText;
    Light light;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();
        light = FindObjectOfType<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = light.GetLife().ToString();
    }
}