﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static GameManager instance;
    public sliderMenuAnim m_PanelDown;

    void Awake()
    {
        instance = this;
    }

}
