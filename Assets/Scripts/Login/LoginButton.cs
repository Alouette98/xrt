using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginButton : MonoBehaviour
{
    public GameObject LoginCanvas;

    public GameObject WelcomeCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoginButtonBehaviour()
    {
        // Debug.LogWarning("--Login button clicked--");
        LoginCanvas.SetActive(true);
        WelcomeCanvas.SetActive(false);
    }
}
