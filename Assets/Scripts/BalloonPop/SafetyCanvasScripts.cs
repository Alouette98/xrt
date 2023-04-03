using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyCanvasScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SafetyCanvasSwitch()
    {
        this.gameObject.GetComponent<Canvas>().enabled = !this.gameObject.GetComponent<Canvas>().enabled;
    }
    
    
}

