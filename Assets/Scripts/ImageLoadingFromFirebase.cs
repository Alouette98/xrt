using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
using SimpleFileBrowser;


public class ImageLoadingFromFirebase : MonoBehaviour
{
    public RawImage rawImage;
    FirebaseStorage storage;
    StorageReference storageReference;
    public GameObject prefabGameObject;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = gameObject.GetComponent<RawImage>();
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://xrt-base.appspot.com");
        
        // LoadImageFromName("uploads/uIUAqttvYYSHfbRN4eY8Q29wNnN2/500.png");
        
    }


    public void LoadImageFromName(string url)
    {
        Debug.Log("url: " + url);
        StorageReference image = storageReference.Child(url);
        
        if (image == null)
        {
            Debug.Log("image is NULL");
        }
        else
        {
            Debug.Log("image is not null");
        }
        
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                StartCoroutine(LoadImage(Convert.ToString(task.Result)));
            }
            else
            {
                Debug.Log(task.Exception);
            }

        });
        StartCoroutine(LoadImage(url));
    }

    IEnumerator LoadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);

        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Debug.Log("[v]Texture successfully loaded");
        }
        
        Transform childObjectTransform = prefabGameObject.transform.Find("RotationWrapper/Balloon/ArtWorkBase/Cube");
        childObjectTransform.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;

        Instantiate(prefabGameObject);

        // GameManager.instance.m_ballonPopController.AnchorVisObjectPrefab = 
    }


}
