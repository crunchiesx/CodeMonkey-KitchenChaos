using UnityEditor;
using UnityEngine;
using System.IO;

public class FolderCreator_Editor : MonoBehaviour
{
    private const string MENU_PATH = "Editor/Create Default Folders";

    [MenuItem(MENU_PATH)]
    static void CreateFolders()
    {
        string[] folders =
        {
            "Scripts",
            "Prefabs",
            "Materials",
            "Scenes",
            "Textures",
            "Audio",
            "Animations"
        };

        foreach (string folder in folders)
        {
            if (!Directory.Exists("Assets/" + folder))
            {
                Directory.CreateDirectory("Assets/" + folder);
            }
        }

        AssetDatabase.Refresh();
    }
}
