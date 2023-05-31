using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderIndicator : MonoBehaviour
{
    public Slider slider_obj;
    public Text text_obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int value = (int)(180f * slider_obj.value);
        text_obj.text = value.ToString();
    }
}
