using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    public void LoadLevelSelect()
    {
        Application.LoadLevel("Level Select");
    }

    public void LoadLevelFromName(string scene)
    {
        Application.LoadLevel(scene);
    }
}
