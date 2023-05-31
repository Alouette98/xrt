using System.Collections;
using System.Collections.Generic;
using TriLibCore.Dae.Schema;
using UnityEngine;

public class ViewerMap : MonoBehaviour
{
    
    public GameObject ViewerMapPanel;

    public Sprite mapon;
    public Sprite mapoff;
    
    
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
        if (ViewerMapPanel.activeSelf)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = mapon;
        }
        else
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = mapoff;
        }
    }
}
