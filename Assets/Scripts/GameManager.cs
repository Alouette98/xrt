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
    public AppState m_AppState;
    public Text m_debugMessage;

    public BalloonPopController m_ballonPopController;
    

    public enum AppState
    {
        Standby,
        Selection,
    }

    void Awake()
    {
        instance = this;
        m_currentSelectedGO = null;
        m_AppState = AppState.Standby;
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
