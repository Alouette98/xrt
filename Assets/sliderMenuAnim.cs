using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderMenuAnim : MonoBehaviour
{
    // public bool OnAndOffState;

    public GameObject panelMenu;
    public Transform main_cam;

    public Vector3 init_Pos;
    public Vector3 ideal_Pos;
    public void Start()
    {
        init_Pos = main_cam.localPosition;
        ideal_Pos = init_Pos;
    }
    public void Update()
    {
        main_cam.position = Vector3.Lerp(main_cam.position, ideal_Pos, Time.deltaTime*2);
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
                    // ================= The panel is closed. now we make it open. ===========
                    
                    // GameManager.instance.m_currentSelectedGO is updated in the Balloon.cs
                    
                    gameObject.GetComponent<UIController>().editing_prefab = GameManager.instance.m_currentSelectedGO.transform.Find("ArtWorkBase");
                    GameManager.instance.LogText(gameObject.GetComponent<UIController>().editing_prefab.name);
                    
                    
                    ideal_Pos = init_Pos + new Vector3(0, -1, 0);
                }   
            else
                {
                // ============== The panel is opend. now we make it close ========

                // GameManager.instance.m_ballonPopController._network.UpdateNewParamOnFirestore()
                
                gameObject.GetComponent<UIController>().UploadLatestParamData();
                GameManager.instance.m_currentSelectedGO = null;
                gameObject.GetComponent<UIController>().editing_prefab = null;
                ideal_Pos = init_Pos;
                }   
            }
        }
    }
}
