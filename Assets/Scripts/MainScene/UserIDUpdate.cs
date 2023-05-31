using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIDUpdate : MonoBehaviour
{
    
    public TMPro.TMP_Text UserIDText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnEnable()
    {
        // Debug.Log("[Info] Home scene loaded.");
        GameManager gm = FindObjectOfType<GameManager>();
        
        if (gm != null)
        {
            UserIDText.text = "Login user ID: " + gm.getUserID();
        }
        else
        {
            UserIDText.text = "111";
        }
        
       
    }
    
}
