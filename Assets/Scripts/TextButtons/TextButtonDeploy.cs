using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButtonDeploy : MonoBehaviour
{

    public GameObject height_obj;
    public GameObject size_obj;
    public GameObject rotation_obj;
    
    // public TMPro.TextMeshPro height_text;
    // public TMPro.TextMeshPro size_text;
    // public TMPro.TextMeshPro rotation_text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void enableHeight()
    {
        // height_text.color = new Color(168f / 255f, 148f / 255f, 252f / 255f);
        // size_text.color = new Color(1f, 1f, 1f);
        // rotation_text.color = new Color(1f, 1f, 1f);

        // height_obj.GetComponent<sliderMenuAnim>().SetShow();
        // size_obj.GetComponent<sliderMenuAnim>().SetShow();
        // rotation_obj.GetComponent<sliderMenuAnim>().SetShow();

        height_obj.SetActive(true);
        size_obj.SetActive(false);
        rotation_obj.SetActive(false);
        
        height_obj.GetComponent<sliderMenuAnim>().SetShow();
        
        // GameManager.instance.m_PanelDown.ShowHideMenu();
    }
    
    public void enableSize()
    {
        // height_obj.GetComponent<sliderMenuAnim>().SetShow();
        // size_obj.GetComponent<sliderMenuAnim>().SetShow();
        // rotation_obj.GetComponent<sliderMenuAnim>().SetShow();
        
        // size_text.color = new Color(168f / 255f, 148f / 255f, 252f / 255f);
        // height_text.color = new Color(1f, 1f, 1f);
        // rotation_text.color = new Color(1f, 1f, 1f);
        // GameManager.instance.m_PanelDown.ShowHideMenu();
        
        height_obj.SetActive(false);
        size_obj.SetActive(true);
        rotation_obj.SetActive(false);
    }
    
    public void enableRotation()
    {
        
        // rotation_text.color = new Color(168f / 255f, 148f / 255f, 252f / 255f);
        // height_text.color = new Color(1f, 1f, 1f);
        // size_text.color = new Color(1f, 1f, 1f);
        //
        
        // GameManager.instance.m_PanelDown.ShowHideMenu();
        
        // height_obj.GetComponent<sliderMenuAnim>().SetShow();
        // size_obj.GetComponent<sliderMenuAnim>().SetShow();
        // rotation_obj.GetComponent<sliderMenuAnim>().SetShow();
        
        height_obj.SetActive(false);
        size_obj.SetActive(false);
        rotation_obj.SetActive(true);
    }
}
