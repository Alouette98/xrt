using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopLeftExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backCanvas;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TopLeftExitButtonBehaviour()
    {
        // Application.Quit();
        backCanvas.SetActive(true);
    }
    
    
}
