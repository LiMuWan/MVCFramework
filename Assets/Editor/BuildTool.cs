using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class BuildTool 
{
    [MenuItem("Tools/BuildAndroid")]
    public static void BuildAndroid()
    {
        string[] levels = {"Assets/Scene/1.unity"};
        string locationPath = Application.dataPath + "/../Bin/";
        string locationApkPath = locationPath + "test.apk";

        if(!Directory.Exists(locationPath))
        {
            Directory.CreateDirectory(locationPath);
        }

        if(File.Exists(locationApkPath))
        {
            File.Delete(locationApkPath);
        }

        BuildPipeline.BuildPlayer(levels, locationApkPath, BuildTarget.Android, BuildOptions.None);
    }
}
