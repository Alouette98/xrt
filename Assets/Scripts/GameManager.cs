using System.Collections;
using System.Collections.Generic;
using Google.CreativeLab.BalloonPop;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static GameManager instance;
    public sliderMenuAnim m_PanelDown;
    public GameObject m_currentSelectedGO;
    public bool b_isEditing;
    public Text m_debugMessage;

    public GameObject m_placementButton; 

    public BalloonPopController m_ballonPopController;
    

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
    }
    
    
    
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
