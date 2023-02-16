using System.Collections;
using System.Collections.Generic;
using Google.CreativeLab.BalloonPop;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Slider slider_size;
    [SerializeField] public Slider slider_X;
    [SerializeField] public Slider slider_Y;
    [SerializeField] public Slider slider_Z;
    [SerializeField] public Transform editing_prefab;
    [SerializeField] public Camera main_cam;

    private Vector3 ini_Scale;
    private Quaternion ini_rotation;
    void Start()
    {
        ini_Scale = editing_prefab.localScale;
        ini_rotation = editing_prefab.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float size_value = Mathf.Pow(5 , slider_size.value);
        editing_prefab.localScale = ini_Scale * size_value;
        Vector3 eulerRotation = new Vector3(slider_X.value, slider_Y.value, slider_Z.value) * 180;
        editing_prefab.localRotation = ini_rotation * Quaternion.Euler(eulerRotation);
    }


    public void UploadLatestParamData()
    {
        BalloonData newBalloonData = GameManager.instance.m_currentSelectedGO.GetComponentInChildren<Balloon>().Data ;
        GameManager.instance.LogText(GetCurrentParam());
        newBalloonData.scale = editing_prefab.localScale.x;
        newBalloonData.rotationX = editing_prefab.localRotation.x;
        newBalloonData.rotationY = editing_prefab.localRotation.y;
        newBalloonData.rotationZ = editing_prefab.localRotation.z;
        GameManager.instance.m_ballonPopController._network.UpdateNewParamOnFirestore(
            newBalloonData,
            (BalloonData bDat) => {
               GameManager.instance.LogText("okkkkkk");
            });
        
        // GameManager.instance.m_currentSelectedGO.GetComponent<Balloon>().SetBalloonData(newBalloonData);
    }
    
    /// <summary>
    /// --- Debug function
    /// </summary>
    /// <returns></returns>
    public string GetCurrentParam()
    {
        return "[localScale] " + editing_prefab.localScale 
                               + "[localRotation] " 
                               + editing_prefab.localRotation;
    }
}
