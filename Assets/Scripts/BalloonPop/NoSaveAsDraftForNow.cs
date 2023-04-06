using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoSaveAsDraftForNow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NoSaveAsDraftForNowBehaviour()
    {
        // Debug.Log("NoSaveAsDraftForNowBehaviour");
        SceneManager.LoadScene(4);
    }
    
}
