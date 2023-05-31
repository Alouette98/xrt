using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignUpButton : MonoBehaviour
{
    [SerializeField]
    public GameObject SignUpCanvas;
    public GameObject WelcomeCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SignUpButtonBehaviour()
    {
        WelcomeCanvas.SetActive(false);
        SignUpCanvas.SetActive(true);
    }
    
}
