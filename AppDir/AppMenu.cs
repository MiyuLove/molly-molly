using UnityEditor;
using UnityEngine;

public class AppMenu {
    static string packageFile = "molly molly.unitypackage";

    [MenuItem ("Custom Menu/Export Backup", false, 0)]
    static void action01 () {
        string[] exportpaths = new string[] {
            "Assets/Animations",
            "Assets/Fonts",
            "Assets/Prefabs",
            "Assets/Scenes",
            "Assets/Scripts",
            "Assets/Textures",
            "ProjectSettings/TagManager.asset",
            "ProjectSettings/EditorBuildSettings.asset"
        };

        AssetDatabase.ExportPackage (exportpaths, packageFile,
            ExportPackageOptions.Interactive |
            ExportPackageOptions.Recurse |
            ExportPackageOptions.IncludeDependencies
        );
        Debug.Log ("Backup Export Complete!");
    }

    [MenuItem ("Custom Menu/Import Backup", false, 1)]
    static void action02 () {
        AssetDatabase.ImportPackage (packageFile, true);
    }


    [MenuItem("Custom Menu/PlayerPrefs All Remove")]
    static void PlayerPrefs_AllRemove()
    {
        PlayerPrefs.DeleteAll();
    }
}