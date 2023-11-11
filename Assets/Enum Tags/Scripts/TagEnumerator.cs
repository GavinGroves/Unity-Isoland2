using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace Tzar
{
    public class TagEnumerator
    {
        const string fileName = "Tags";
        const string fileExtensions = ".cs";

        static string[] tags;

        static string previousClassText;
        static string pathToThis = string.Empty;

        [InitializeOnLoadMethod]
        static void Initialize()
        {
            EditorApplication.update += Update;
        }

        static void Update()
        {
            // Get tags
            tags = UnityEditorInternal.InternalEditorUtility.tags;

            // Get the path to this script
            GetPathToThis();

            // Combine the directory path with the file name to get the full file path
            string filePath = Path.Combine(pathToThis, fileName + fileExtensions);

            // Combine the whole class string
            string classText = "public static class " + fileName + "\n{\n" + GetPropertyMembersString() + "}";

            // Save only if there's changes
            if (previousClassText != classText)
            {
                File.WriteAllText(filePath, classText);
                previousClassText = classText;
                //Debug.Log("Updated Enumerated Tags");
            }
        }

        static void GetPathToThis()
        {
            if (pathToThis.Length == 0)
            {
                string thisName = "TagEnumerator.cs";

                string[] res = Directory.GetFiles(Application.dataPath, thisName, SearchOption.AllDirectories);

                if (res.Length == 0)
                {
                    Debug.LogError("Couldn't find path to TagEnumerator");
                }
                else
                {
                    pathToThis = res[0].Replace(thisName, "").Replace("\\", "/");
                }
            }
        }

        static string GetPropertyMembersString()
        {
            string members = string.Empty;

            for (int i = 0; i < tags.Length; i++)
            {
                members = members + "public const string T_" + ClearSpecialCharacters(tags[i]) + " = @\"" + tags[i] + "\";\n";
            }

            return members;
        }

        static string ClearSpecialCharacters(string str)
        {
            string pattern = "[^a-zA-Z0-9]";
            string replacement = "SC";
            string result = Regex.Replace(str, pattern, replacement);

            return result;
        }
    }
}

#endif