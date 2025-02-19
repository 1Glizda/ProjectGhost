// Assets/Editor/WebGLBuild.cs
using UnityEditor;
using System.IO;

public class WebGLBuild
{
    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        string buildPath = "Builds/WebGL";
        if (!Directory.Exists(buildPath))
            Directory.CreateDirectory(buildPath);
        
        // List all scenes you want in the build
        string[] scenes = { "Assets/Scene1.unity", "Assets/Scene2.unity" };
        
        BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.WebGL, BuildOptions.None);
    }
}
