using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScreenCaptureUtil))]
public class ScreenCaptureUtilEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Take Screenshot"))
        {
            ScreenCaptureUtil screenCaptureUtil = (ScreenCaptureUtil)target;
            screenCaptureUtil.TakeScreenshot();
        }
    }
}
