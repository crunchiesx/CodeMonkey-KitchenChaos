using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class AutoPingHierarchy_Editor
{
    private const string MENU_PATH = "Editor/Auto Ping Hierarchy";
    private static bool isEnabled = default;

    static GameObject lastSelected;

    static AutoPingHierarchy_Editor()
    {
        // Load saved state from EditorPrefs
        isEnabled = EditorPrefs.GetBool(MENU_PATH, true);

        // Subscribe to update loop
        EditorApplication.update += OnEditorUpdate;

        // Set checkmark in menu
        Menu.SetChecked(MENU_PATH, isEnabled);
    }

    // Add menu toggle
    [MenuItem(MENU_PATH)]
    private static void ToggleAutoPing()
    {
        isEnabled = !isEnabled;
        EditorPrefs.SetBool(MENU_PATH, isEnabled);
        Menu.SetChecked(MENU_PATH, isEnabled);
    }

    private static void OnEditorUpdate()
    {
        if (!isEnabled) return;

        if (Selection.activeGameObject != null && Selection.activeGameObject != lastSelected)
        {
            lastSelected = Selection.activeGameObject;
            EditorGUIUtility.PingObject(lastSelected);
        }
    }
}