using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployPlaceBtn : MonoBehaviour
{

    public GameObject m_placeholder;
    
    public GameObject modifyCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void DisablePlaceholder()
    {
        m_placeholder.SetActive(false);
        modifyCanvas.SetActive(true);
        gameObject.GetComponent<Image>().enabled = false;

        // last step: disable this button
        // this.gameObject.SetActive(false);

    }
}
