using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToAboutBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BackToAboutBtnBehaviour()
    {
        // Debug.LogWarning("Back to about button clicked");
        SceneManager.LoadScene(5);
    }
}
