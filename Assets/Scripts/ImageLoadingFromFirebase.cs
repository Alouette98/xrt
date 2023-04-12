﻿using System;
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

    // Start is called before the first frame update
    void Awake()
    {
        rawImage = gameObject.GetComponent<RawImage>();
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://xrt-base.appspot.com");
        
        // LoadImageFromName("uploads/uIUAqttvYYSHfbRN4eY8Q29wNnN2/500.png");
        
    }


    public void LoadImageFromName(string url, GameObject inputGameObject)
    {
        Debug.Log("url: " + url);
        StorageReference image = storageReference.Child(url);
        
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                StartCoroutine(LoadImage(Convert.ToString(task.Result), inputGameObject));
                // return inputGameObject;
            }
            else
            {
                Debug.Log(task.Exception);
            }
        });
        
    }

    IEnumerator LoadImage(string MediaUrl, GameObject inputGameObject)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);

        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            
            Transform childObjectTransform = inputGameObject.transform.Find("RotationWrapper/Balloon/ArtWorkBase/Cube");
            //childObjectTransform.GetComponent<Renderer>().material = new Material(Shader.Find("Specular"));
            childObjectTransform.GetComponent<Renderer>().sharedMaterial.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            childObjectTransform.GetComponent<Renderer>().sharedMaterial.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Debug.Log("----Successful----");

        }

    }


}
