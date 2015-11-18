using UnityEngine;
using System.Collections;

public class LevelEndMarker : MonoBehaviour
{
    LevelController levelController;

    void OnBecameVisible()
    {
        levelController.LevelEnd();
    }    
}