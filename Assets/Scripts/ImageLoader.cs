using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;

public class ImageLoader : MonoBehaviour
{
    RawImage rawImage;
    FirebaseStorage storage;
    StorageReference storageReference;


   IEnumerator LoadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }

    }

    void Start()
    {
        rawImage = gameObject.GetComponent<RawImage>();
        //StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/xrt-base.appspot.com/o/old-paper-2133481_1280.jpg?alt=media&token=17704488-eb4a-40df-8214-77e0a0e51eae"));

        //initialize storage reference
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://xrt-base.appspot.com");

        StorageReference image = storageReference.Child("old-paper-2133481_1280.jpg");

        //get download link of file
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if(!task.IsFaulted && !task.IsCanceled)
            {
                StartCoroutine(LoadImage(Convert.ToString(task.Result)));
;            }
            else
            {
                Debug.Log(task.Exception);
            }

        });

    }

    void Update()
    {

    }
}
