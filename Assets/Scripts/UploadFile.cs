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
    public GameObject uploadingcanvas;

    private GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        
        FileBrowser.SetFilters(true, 
            new FileBrowser.Filter("Images", ".jpg", ".png"), 
            new FileBrowser.Filter("Text Files", ".txt", ".pdf"), 
            new FileBrowser.Filter("Model Files", ".fbx", ".obj", ".glb"));

        FileBrowser.SetDefaultFilter(".jpg");


        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://xrt-base.appspot.com");


    }

    public void OnButtonClick()
    {
        StartCoroutine(ShowLoadDialogCoroutine()); //simpleFileBrower way
        //PickFileName();

    }


    void PickFileName()
    {
        string FileType = "*/*";
        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
        {
            if(path == null)
            {
                Debug.Log("Operation cancelled");
            }
            else
            {
                string fileName = ProcessFileName(Path.GetFileName(path));
                Debug.Log("read file " + fileName);



                FinishUploading(fileName);
            }
        }, new string[] { FileType });
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

            string fileName = ProcessFileName( Path.GetFileName(FileBrowser.Result[0]));
            Debug.Log("this is "+ fileName);


            
            //Editing Metadata
            var newMetadata = new MetadataChange();
            //we need a parser to defien "image/jpg"
            newMetadata.ContentType = "image/jpg";

            //Create a reference to where the file needs to be uploaded
            StorageReference uploadRef = storageReference.Child("uploads/" + fileName);
            Debug.Log("File upload started");
            
            uploadingcanvas.SetActive(true);    
            uploadRef.PutBytesAsync(bytes, newMetadata).ContinueWithOnMainThread((task) => {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.Log(task.Exception.ToString());
                }
                else
                {
                    Debug.Log("File Uploaded Successfully!");
                    uploadingcanvas.SetActive(false);
                    Debug.LogWarning(">>>>>>>>>>>>>>>" + task.Result.Path);
                    FinishUploading(task.Result.Path);
                }
            });
            
            FinishUploading(fileName);
        }
    }

    public void FinishUploading(string path)
    {
        Debug.Log("Successfully get file path");
        GameManager.instance.pathTo2DAsset = path;
        SceneManager.LoadScene(5);
    }


    private string  ProcessFileName(string path)
    {
        string[] strElements = path.Split(new string[] {"%2F"}, System.StringSplitOptions.None);
        //strElements[strElements.Length - 1].Split()
        return strElements[strElements.Length - 1];
    }
}