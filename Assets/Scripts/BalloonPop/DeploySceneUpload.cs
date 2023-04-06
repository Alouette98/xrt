using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySceneUpload : MonoBehaviour
{
    
    public GameObject SuccessfulUploadCanvas;

    public GameObject ConfirmCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeployScenePublish()
    {
        ConfirmCanvas.SetActive(false);
        SuccessfulUploadCanvas.SetActive(true);
    }
}
