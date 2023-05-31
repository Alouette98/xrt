using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArtWorkConfig : MonoBehaviour
{
    [Serializable]
    public struct NamedImage
    {
        public string name;
        public GameObject artwork;
    }
    public NamedImage[] pictures;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
