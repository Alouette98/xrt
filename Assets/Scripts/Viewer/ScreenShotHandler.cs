using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{

    
    private string fileName;
    
    // Call this method to capture a screenshot
    public void CaptureScreenshot()
    {
        // generate a string with the current date and time
        fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        
        // Create a texture with the same size as the screens
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        
        // Read the pixels from the screen and store them in the texture
        screenshotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        
        // Apply the changes to the texture
        screenshotTexture.Apply();
        
        // Convert the texture to a byte array
        byte[] screenshotBytes = screenshotTexture.EncodeToPNG();
        
        // Save the byte array as a PNG image file
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllBytes(path, screenshotBytes);
        
        Debug.Log("Screenshot saved at " + path);
    }
    
}
