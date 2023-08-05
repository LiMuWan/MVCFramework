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
         string[] levels = new string[EditorBuildSettings.scenes.Length];
        for(int i = 0;i< EditorBuildSettings.scenes.Length;i++)
        {
            levels[i] = EditorBuildSettings.scenes[i].path;
        }
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
