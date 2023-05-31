using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class sliderMenuAnim : MonoBehaviour
{
    // public bool OnAndOffState;
    public UIController m_UIController;

    public GameObject panelMenu;
    public Transform main_cam;

    public Vector3 init_Pos;
    public Vector3 ideal_Pos;

    // public GameObject btn1;
    // public GameObject btn2;
    // public GameObject btn3;
    // public GameObject overlayerbtn;
    
    public void Start()
    {
        init_Pos = main_cam.localPosition;
        ideal_Pos = init_Pos;
    }
    public void Update()
    {
        main_cam.position = Vector3.Lerp(main_cam.position, ideal_Pos, Time.deltaTime*2);
    }

// getter and setter
    public bool GetShow()
    {
        Animator anim = panelMenu.GetComponent<Animator>();
        return anim.GetBool("show");
    }

    public void SetShow()
    {
        Animator anim = panelMenu.GetComponent<Animator>();
        anim.SetBool("show", !GetShow());
    }
    
    
    public void ShowHideMenu()
    {
        if(panelMenu != null)
        {
            Animator anim = panelMenu.GetComponent<Animator>();
            if(anim != null)
            {
                bool isOpen = anim.GetBool("show");

                anim.SetBool("show", !isOpen);
                if (!isOpen)
                {
                    GameManager.instance.LogText("```open```");
                    // ================= The panel is closed. now we make it open. ===========
                    
                    GameManager.instance.m_placementButton.SetActive(false);
                    m_UIController.AssignNewTarget(GameManager.instance.m_currentSelectedGO);
                    GameManager.instance.b_isEditing = true;
                    
                    // overlayerbtn.SetActive(false);
                    
                    // btn1.SetActive(true);
                    // btn2.SetActive(true);
                    // btn3.SetActive(true);
                    
                    ideal_Pos = init_Pos + new Vector3(0, -1, 0);
                }   
            else
                {
                // ============== The panel is opend. now we make it close ========
                GameManager.instance.LogText("```close```");

                m_UIController.UploadLatestParamData();
                m_UIController.UnAssignCurrTarget();
                GameManager.instance.m_currentSelectedGO = null;
                
                GameManager.instance.b_isEditing = false;
                GameManager.instance.m_placementButton.SetActive(true);
                ideal_Pos = init_Pos;
                }   
            }
        }
    }
}
