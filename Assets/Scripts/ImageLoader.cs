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


namespace TriLibCore.Samples
{
    public class ImageLoader : MonoBehaviour
    {
        RawImage rawImage;
        GameObject objectAsset;
        FirebaseStorage storage;
        StorageReference storageReference;
        public GameObject prefabGameObject;


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
                rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }

        }

        IEnumerator LoadAsset(string MediaUrl)
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(MediaUrl);

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();
                var webRequest = AssetDownloader.CreateWebRequest(MediaUrl);
                AssetDownloader.LoadModelFromUri(webRequest, OnLoad, OnMaterialsLoad, OnProgress, OnError, null, assetLoaderOptions);
                //objectAsset = (DownloadHandlerAssetBundle)request.downloadHandler;
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
                if (!task.IsFaulted && !task.IsCanceled)
                {
                    
                    Debug.Log(Convert.ToString(">>>>>>>>>>>" + task.Result));
                    StartCoroutine(LoadImage(Convert.ToString(task.Result)));
                    ;
                }
                else
                {
                    Debug.Log(task.Exception);
                }

            });
            
            
            // ------  Downloading fbx file from firebase storage  ------
            
            // storageReference obj2 = storageReference.

            StorageReference obj = storageReference.Child("uploads/test.fbx");

            const long maxAllowedSize = 16 * 4096 * 4096;
            obj.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.LogException(task.Exception);
                    // Uh-oh, an error occurred!
                }
                else
                {
                    byte[] fileContents = task.Result;
                    FileBrowserHelpers.WriteBytesToFile("download_asset.fbx", fileContents);
                    Debug.Log("Finished downloading!");
                }
            });

            var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();

            GameObject parentObject = Instantiate(prefabGameObject);
            Transform childObjectTransform = parentObject.transform.Find("RotationWrapper/Balloon/ArtWorkBase");
            if (childObjectTransform == null)
            {
                Debug.LogError("Child object not found");
            }
            else
            {
                Debug.Log("Child object found successfully");
            }
            
            AssetLoader.LoadModelFromFile("download_asset.fbx", OnLoad, OnMaterialsLoad, OnProgress, OnError, childObjectTransform.gameObject , assetLoaderOptions);

        }

        void Update()
        {

        }




        /*file loader
          */

        private void OnError(IContextualizedError obj)
        {
            Debug.LogError($"An error occurred while loading your Model: {obj.GetInnerException()}");
        }

        /// <summary>
        /// Called when the Model loading progress changes.
        /// </summary>
        /// <param name="assetLoaderContext">The context used to load the Model.</param>
        /// <param name="progress">The loading progress.</param>
        private void OnProgress(AssetLoaderContext assetLoaderContext, float progress)
        {
            Debug.Log($"Loading Model. Progress: {progress:P}");
        }

        /// <summary>
        /// Called when the Model (including Textures and Materials) has been fully loaded.
        /// </summary>
        /// <remarks>The loaded GameObject is available on the assetLoaderContext.RootGameObject field.</remarks>
        /// <param name="assetLoaderContext">The context used to load the Model.</param>
        private void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
        {
            Debug.Log("Materials loaded. Model fully loaded.");
        }

        /// <summary>
        /// Called when the Model Meshes and hierarchy are loaded.
        /// </summary>
        /// <remarks>The loaded GameObject is available on the assetLoaderContext.RootGameObject field.</remarks>
        /// <param name="assetLoaderContext">The context used to load the Model.</param>
        private void OnLoad(AssetLoaderContext assetLoaderContext)
        {
            Debug.Log("Model loaded. Loading materials.");
        }

    }
}