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
        // if (editing_prefab)
        // {
            // ini_Scale = editing_prefab.localScale;
            // ini_rotation = editing_prefab.localRotation;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.b_isEditing)
            {
                float size_value = Mathf.Pow(5, slider_size.value);
                editing_prefab.localScale = ini_Scale * size_value;
                Vector3 eulerRotation = new Vector3(slider_X.value, slider_Y.value, slider_Z.value) * 180;
                editing_prefab.localRotation = ini_rotation * Quaternion.Euler(eulerRotation);
            }
        }
        
    }
    public void AssignNewTarget(GameObject inputGameObject)
    {
        
        // Currently, the ArtBase has 1,1,1 scale. 
        // May need updates later.

        ini_Scale = new Vector3(1,1,1);
        ini_rotation = Quaternion.Euler(0,0,0);
        
        this.slider_size.value = inputGameObject.GetComponentInChildren<Balloon>().Data.slider_size_value;
        this.slider_X.value = inputGameObject.GetComponentInChildren<Balloon>().Data.slider_X_value;
        this.slider_Y.value = inputGameObject.GetComponentInChildren<Balloon>().Data.slider_Y_value;
        this.slider_Z.value = inputGameObject.GetComponentInChildren<Balloon>().Data.slider_Z_value;
        
        this.editing_prefab = inputGameObject.transform.Find("ArtWorkBase");
        
        // this.editing_prefab.localScale = new Vector3(inputGameObject.GetComponentInChildren<Balloon>().Data.scale,
        //     inputGameObject.GetComponentInChildren<Balloon>().Data.scale,
        //     inputGameObject.GetComponentInChildren<Balloon>().Data.scale);
        //
        // this.editing_prefab.localRotation = Quaternion.Euler(
        //     inputGameObject.GetComponentInChildren<Balloon>().Data.rotationX,
        //     inputGameObject.GetComponentInChildren<Balloon>().Data.rotationY,
        //     inputGameObject.GetComponentInChildren<Balloon>().Data.rotationZ);
        
    }
    
    public void UnAssignCurrTarget()
    {
        this.slider_size.value = 0f;
        this.slider_X.value = 0f;
        this.slider_Y.value = 0f;
        this.slider_Z.value = 0f;
        this.editing_prefab = null;
    }

    public void UploadLatestParamData()
    {
        BalloonData newBalloonData = GameManager.instance.m_currentSelectedGO.GetComponentInChildren<Balloon>().Data ;
        GameManager.instance.LogText(GetCurrentParam());
        newBalloonData.scale = editing_prefab.localScale.x;
        newBalloonData.rotationX = editing_prefab.localRotation.eulerAngles.x;
        newBalloonData.rotationY = editing_prefab.localRotation.eulerAngles.y;
        newBalloonData.rotationZ = editing_prefab.localRotation.eulerAngles.z;

        newBalloonData.slider_size_value = slider_size.value;
        newBalloonData.slider_X_value = slider_X.value;
        newBalloonData.slider_Y_value = slider_Y.value;
        newBalloonData.slider_Z_value = slider_Z.value;

        GameManager.instance.m_ballonPopController._network.UpdateNewParamOnFirestore(
            newBalloonData,
            (BalloonData bDat) => {
               // GameManager.instance.LogText("-uploaded-");
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
