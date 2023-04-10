using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPlaceBtn : MonoBehaviour
{

    public GameObject m_placeholder;
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
    }
}
