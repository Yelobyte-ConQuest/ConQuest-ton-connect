using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrientationManager : MonoBehaviour
{
    private void Start()
    {
        // Set the screen orientation based on the current scene
        SetOrientationForScene(SceneManager.GetActiveScene().name);

        // Subscribe to the scene change event
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene change event to avoid memory leaks
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        // Adjust orientation based on the new active scene
        SetOrientationForScene(newScene.name);
    }

    private void SetOrientationForScene(string sceneName)
    {
        // Assuming the main app scene is called "MainApp" and mini-games are "MiniGame1", "MiniGame2", etc.
        if (sceneName == "Main")
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.SetResolution(1080, 1920, true); // True for fullscreen mode
        }
        else if (sceneName.Contains("SubAttack"))
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Screen.SetResolution(1920, 1080, true); // Set to landscape resolution
        }
    }
}

