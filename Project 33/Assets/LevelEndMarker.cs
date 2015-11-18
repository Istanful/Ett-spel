using UnityEngine;
using System.Collections;

public class LevelEndMarker : MonoBehaviour
{
    // Use this for initialization
    void OnBecameVisible()
    {
        Debug.Log("Level Ended.");
        GameObject.Find("LevelController").GetComponent<LevelController>().scrollingMultiplier = 0;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector3.right * 25;
        GameObject.Find("EnemySpawner").SetActive(false);
        Camera.main.GetComponent<LevelCameraController>().followObject = null;
    }    
}