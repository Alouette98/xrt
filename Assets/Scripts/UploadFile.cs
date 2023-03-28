using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//For Picking files
using System.IO;
using SimpleFileBrowser;

//For firebase storage
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine.SceneManagement;

public class UploadFile : MonoBehaviour
{
    FirebaseStorage storage;
    StorageReference storageReference;

    private GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"), new FileBrowser.Filter("Model Files", ".fbx", ".obj"));

        FileBrowser.SetDefaultFilter(".jpg");


        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://xrt-base.appspot.com");


    }

    public void OnButtonClick()
    {
        StartCoroutine(ShowLoadDialogCoroutine());

    }

    IEnumerator ShowLoadDialogCoroutine()
    {

        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
        {
            // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
            for (int i = 0; i < FileBrowser.Result.Length; i++)
                Debug.Log(FileBrowser.Result[i]);

            Debug.Log("File Selected");
            byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);
            //FileBrowserHelpers.WriteBytesToFile("tttt.jpg", bytes);

            string fileName = ProcessFileName(FileBrowser.Result[0]);
            //Editing Metadata
            var newMetadata = new MetadataChange();
            //we need a parser to defien "image/jpg"
            newMetadata.ContentType = "model/fbx";

            //Create a reference to where the file needs to be uploaded
            StorageReference uploadRef = storageReference.Child("uploads/" + gm.getUserID() + "/" + fileName);
            Debug.Log("File upload started");
            uploadRef.PutBytesAsync(bytes, newMetadata).ContinueWithOnMainThread((task) => {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.Log(task.Exception.ToString());
                }
                else
                {
                    Debug.Log("File Uploaded Successfully!");
                    // Debug.LogWarning(">>>" + uploadRef.GetDownloadUrlAsync().Result);
                    // Debug.LogWarning(uploadRef.GetDownloadUrlAsync().Result);
                    // Debug.LogWarning(">>>>>>>>>>>>>>>" + task.Result.Path);
                    FinishUploading(task.Result.Path);
                }
            });
            
            



        }
    }

    public void FinishUploading(string path)
    {
        Debug.Log("Successfully get file path");
        GameManager.instance.pathTo2DAsset = path;
        SceneManager.LoadScene(3);
    }


    private string  ProcessFileName(string path)
    {
        string[] strElements = path.Split('\\');
        return strElements[strElements.Length - 1];
    }
}