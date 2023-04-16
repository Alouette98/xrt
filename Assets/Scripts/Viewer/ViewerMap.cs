using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerMap : MonoBehaviour
{
    
    public GameObject ViewerMapPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ViewerMapBehaviour()
    {
        // Destroy(GameManager.instance);
        // SceneManager.LoadScene(6);\
        ViewerMapPanel.SetActive(ViewerMapPanel.activeSelf ? false : true);
    }
}
