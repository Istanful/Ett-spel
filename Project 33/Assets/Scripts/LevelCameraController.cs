using UnityEngine;
using System.Collections;

public class LevelCameraController : MonoBehaviour
{
    public GameObject followObject;
    public float xOffset;
    public float yOffset;
    public float screenRatio;

    void Update()
    {
        Camera.main.orthographicSize = (42 - 1) / Camera.main.aspect * 2;
        
        if (followObject != null)
            transform.position = new Vector3(followObject.transform.position.x + xOffset, followObject.transform.position.y + yOffset, transform.position.z);
    }
}