using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void LoadLevelFromName(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
