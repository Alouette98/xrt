using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoLoader : MonoBehaviour
{
    // Start is called before the first frame update
    

    public TMPro.TMP_Text Title;
    public TMPro.TMP_Text Description;
    public TMPro.TMP_Text debugMessage;
    
    void Start()
    {
        GameManager.instance.m_infoLoader = this;
        GameManager.instance.sceneName = "view";
    }

    [Serializable]
    public struct DescriptionArtwork
    {
        public string filename;
        public string title;
        public string description;
    }
    
    [SerializeField] public List<DescriptionArtwork> descriptions;



    public void LoadDescription(string givenName)
    {
        debugMessage.text = givenName;
        foreach (DescriptionArtwork work in descriptions)
        {
            
            if (work.filename == givenName)
            {
                // Debug.Log("Found description for " + givenName);
                
                Title.text = work.title;
                Description.text = work.description;

                return;
                // GameManager.instance.m_debugMessage.text = work.description;
            }
            
        }
        
        Title.text = "Untitled";
        Description.text = "No description available";

    }
    
}
