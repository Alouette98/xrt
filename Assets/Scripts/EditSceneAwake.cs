using System.Collections;
using System.Collections.Generic;
using Google.CreativeLab.BalloonPop;
using UnityEngine;
using UnityEngine.UI;
public class EditSceneAwake : MonoBehaviour
{
    
    public sliderMenuAnim m_PanelDown;
    public Text m_debugMessage;
    public GameObject m_placementButton; 
    public BalloonPopController m_ballonPopController;
    ImageLoadingFromFirebase m_imageLoadingFromFirebase;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.m_PanelDown = m_PanelDown;
        GameManager.instance.m_debugMessage = m_debugMessage;
        GameManager.instance.m_placementButton = m_placementButton;
        GameManager.instance.m_ballonPopController = m_ballonPopController;
        m_imageLoadingFromFirebase = this.gameObject.GetComponent<ImageLoadingFromFirebase>();
        m_imageLoadingFromFirebase.LoadImageFromName(GameManager.instance.pathTo2DAsset);
        // m_imageLoadingFromFirebase.LoadImageFromName("old-paper-2133481_1280.jpg");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
