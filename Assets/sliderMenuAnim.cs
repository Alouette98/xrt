using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderMenuAnim : MonoBehaviour
{
    public bool OnAndOffState;

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
                    OnAndOffState = true;
                    ideal_Pos = init_Pos + new Vector3(0, -1, 0);
                }   
            else
                {
                OnAndOffState = false;
                ideal_Pos = init_Pos;
                }   
            }
        }
    }
}
