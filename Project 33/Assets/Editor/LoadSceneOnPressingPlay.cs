using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


/*
[InitializeOnLoad]
public static class LoadSceneOnPressingPlay
{
[SerializeField]
public static string oldScene;

static LoadSceneOnPressingPlay()
{
EditorApplication.playmodeStateChanged += StateChange;
}

static void StateChange()
{
if (EditorApplication.isPlaying)
{
    EditorApplication.playmodeStateChanged -= StateChange;
    if (!EditorApplication.isPlayingOrWillChangePlaymode)
    {
        //We're in playmode, just about to change playmode to Editor
        Debug.Log("Loading original level");
        EditorSceneManager.OpenScene(oldScene);
    }
    else
    {
        //We're in playmode, right after having pressed Play
        oldScene = EditorApplication.currentScene;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Left shift held, keeping current level loaded");
        }
        else
        {
            Debug.Log("Loading first level");
            SceneManager.LoadScene(0);
        }
    }
}
}
}
*/