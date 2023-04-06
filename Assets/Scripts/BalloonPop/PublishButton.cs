using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublishButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject confirmCanvas;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PublishButtonBehaviour()
    {
        // Debug.LogWarning("Publish button clicked");
        confirmCanvas.SetActive(true);
    }
    
}
