using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDebugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDebugMessage()
    {
        Debug.LogWarning("--Button clicked--");
    }
}
