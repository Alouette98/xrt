using System;
using System.Collections;
using System.Collections.Generic;
using Google.CreativeLab.BalloonPop;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // USER ID

    public static string UserID;
    
    
    // Start is called before the first frame update
    public static GameManager instance;
    public sliderMenuAnim m_PanelDown;
    public GameObject m_currentSelectedGO;
    public bool b_isEditing;
    public Text m_debugMessage;

    public GameObject m_placementButton; 

    public BalloonPopController m_ballonPopController;

    public String pathTo2DAsset;

    public ImageLoadingFromFirebase m_imageLoadingFromFirebase;

    public string sceneName;
    
    public InfoLoader m_infoLoader;

    public string getUserID()
    {
        return UserID;
    }

    // public enum AppState
    // {
    //     Standby,
    //     Editing,
    // }

    void Awake()
    {
        instance = this;
        m_currentSelectedGO = null;
        b_isEditing = false;
        
        UserID = "";
    }


    // public void UpdateUserIDOnHomePage()
    // {
    //     
    // }
    //
    
    
    /// <summary>
    /// Universal debug function.
    /// </summary>
    /// <param name="message"></param>
    public void LogText(string message)
    {
        m_debugMessage.text += "\t" + message;
    }

    void Update()
    {
        
    }

}
