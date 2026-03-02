#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class StartupSceneLoader
{
    static StartupSceneLoader()
    {
        EditorApplication.delayCall += () =>
        {
            if (!EditorApplication.isPlaying)
            {
                EditorSceneManager.OpenScene("Assets/Project/Scenes/Showroom_Root.unity");
            }
        };
    }
}
#endif