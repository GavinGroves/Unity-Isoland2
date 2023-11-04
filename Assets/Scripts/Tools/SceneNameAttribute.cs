using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tools
{
    public class SceneNameAttribute : PropertyAttribute
    {
        public string[] NameList => SceneNameAttribute.AllSceneNames();

        public static string[] AllSceneNames()
        {
            List<string> stringList = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    string str1 = scene.path.Substring(scene.path.LastIndexOf('/') + 1);
                    string str2 = str1.Substring(0, str1.Length - 6);
                    stringList.Add(str2);
                }
            }

            return stringList.ToArray();
        }
    }
}