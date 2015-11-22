using UnityEngine;
using System.Collections;

public class LevelEndMarker : MonoBehaviour
{
    void OnBecameVisible()
    {
        GameController.PlayerWon();
        Destroy(gameObject);
    }    
}