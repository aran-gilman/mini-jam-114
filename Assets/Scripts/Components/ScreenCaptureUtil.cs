using UnityEngine;

public class ScreenCaptureUtil : MonoBehaviour
{
    public string baseFilename;
    public string extension = "png";
    public int suffix;

    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot($"{baseFilename}_{suffix}.{extension}");
        suffix++;
    }
}
